﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class FIActivity : Form
    {
        public FIActivity()
        {
            InitializeComponent();
        }

        //public FIActivity(int detailId)
        //{
        //    InitializeComponent();

        //    detId = detailId;
        //    detailActivity = FIDetailActivity.Select(detailId);

        //    gridControl1.DataSource = new BindingList<FIDetailActivity>(detailActivity);
        //}

        public FIActivity(FIDetail givenDetail, int givenPlaceholderId = 0, int givenAuditeeRole = 0)
        {
            InitializeComponent();

            if (UserInfo.roleDetails.IsAdmin)
            {
                MIadminChangeFont.Visible = true;
            }

            UserAuth.ArrangeMenuItems(UserInfo.roleDetails, menuStrip1);

            if (givenAuditeeRole == 1)//1.GM
            {
                tsmiMTinformIA.Enabled = false;
                tsmiMTreplyIA.Enabled = false;
                tsmiMTdelegateDT.Enabled = false;
                tsmiMTreplyDT.Enabled = false;
                tsmiDTreplyMT.Enabled = false;
                tsmiMTextendIA.Enabled = false;

                rtbComments.Enabled = false;
                btnAttachment.Enabled = false;
                btnSaveDraft.Enabled = false;
                btnFontDialog.Enabled = false;
                MIcopyComments.Enabled = false;
                MIcopyAttachments.Enabled = false;
            }
            else if (givenAuditeeRole == 2)//2.MT
            {
                tsmiDTreplyMT.Enabled = false;
            }
            else if (givenAuditeeRole == 3)//3.DT
            {
                tsmiMTinformIA.Enabled = false;
                tsmiMTreplyIA.Enabled = false;
                tsmiMTdelegateDT.Enabled = false;
                tsmiMTreplyDT.Enabled = false;
                tsmiMTextendIA.Enabled = false;
            }

            det = givenDetail;
            //detId = givendetail.Id;

            //--------------------
            //if (givenPlaceholderId > 0 && givenAuditeeRole > 0) //MT, DT
            //{
            //    PHolder = new Placeholders(givenPlaceholderId);
            //    AuditeeRole = new AuditeesRoles(givenAuditeeRole);
            //} 
            //detailActivity = FIDetailActivity.Select(givenDetail.Id, givenPlaceholderId, givenAuditeeRole);
            //--------------------

            choosenRole = "";
            if (givenAuditeeRole > 0)
            {
                AuditeeRole = new AuditeesRoles(givenAuditeeRole);
                choosenRole += AuditeeRole.Name;
            }

            if (givenPlaceholderId > 0) //Mt, Dt actions
            {
                PHolder = new Placeholders(givenPlaceholderId);
                choosenRole += "-" + PHolder.Department.Name + "(" + PHolder.Company.Name+")";
            }

            if (choosenRole == "")
            {
                choosenRole += UserInfo.roleDetails.Name;
            }

            
            tsStatusLblUser.Text = "Role: " + choosenRole;

            detailActivity = FIDetailActivity.Select(givenDetail.Id, givenPlaceholderId, givenAuditeeRole);
            
            //Update empty cells that have no user - with IA
            List<int> actDescrFrom = new List<int>() { 1, 3, 10, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            detailActivity.Where(i => actDescrFrom.Contains(i.ActivityDescription.Id)).Select(i => { i.FromUser.FullName = "IA"; return i; }).ToList();
            List<int> actDescrTo = new List<int>() { 2, 4, 8, 13, 14, 15, 17, 18, 19, 23, 24, 25 };
            detailActivity.Where(i => actDescrTo.Contains(i.ActivityDescription.Id)).Select(i => { i.ToUser.FullName = "IA"; return i; }).ToList();

            gridControl1.DataSource = new BindingList<FIDetailActivity>(detailActivity);

            //get draft
            rtbComments.Rtf = FIDetailActivity.getDraftRtf(givenDetail.Id, givenPlaceholderId, UserInfo.userDetails.Id);

            //---------------------
            completeAudit = Audit.SelectAuditHeaderDetailFromDetailId(givenDetail.Id).First();

            txtCompany.Text = completeAudit.Company.Name;
            txtAuditRef.Text = completeAudit.AuditRef;
            txtFIId.Text = completeAudit.FIHeaders[0].FIId;
            txtFISubId.Text = givenDetail.FISubId; //completeAudit.FIHeaders[0].FIDetails[0].FISubId; //
            txtActionCode.Text = givenDetail.ActionCode;
            txtCategory.Text = completeAudit.FIHeaders[0].FICategory.Name;
            txtAuditTitle.Text = completeAudit.Title;
            txtHeaderTitle.Text = completeAudit.FIHeaders[0].Title;
            txtDescription.Text = givenDetail.Description;
            txtActionReq.Text = givenDetail.ActionReq;
            //---------------------

            
            if (givenDetail.ActionDt != null)
            {
                dtpDetail_ActionDate.CustomFormat = "dd.MM.yyyy";
                dtpDetail_ActionDate.Value = (DateTime)givenDetail.ActionDt;
            }

            gridView1.Columns["Id"].Visible = UserInfo.roleDetails.IsAdmin;
            gridView1.Columns["DetailId"].Visible = UserInfo.roleDetails.IsAdmin;
        }

        //public int detId;
        public List<FIDetailActivity> detailActivity = new List<FIDetailActivity>();
        public FIDetail det = new FIDetail();

        public Placeholders PHolder = new Placeholders();
        public AuditeesRoles AuditeeRole = new AuditeesRoles();

        public string choosenRole;
        public Audit completeAudit = new Audit();

        UserAuthorization UserAuth = new UserAuthorization();

        //private bool bwSuccess = false;

        private void btnFontDialog_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = true;

            fontDialog1.Font = rtbComments.SelectionFont;
            fontDialog1.Color = rtbComments.SelectionColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                rtbComments.SelectionFont = fontDialog1.Font;
                rtbComments.SelectionColor = fontDialog1.Color;
            }

        }
        
        //============================================================

        private void MT_tsmiMTinformIA_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_MTinformIA, null, null, det, AuditeeRole.Id, PHolder.Id))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Inform IA for WIP. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
                        
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(4);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.Placeholders = this.PHolder;

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments
                string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");

                Cursor oldCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                AuditOwners iaOwners = FIDetail.getAuditOwners(det.Id);
                emailProps.Recipients = iaOwners.getRecipients(false);
                emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                if (Email.SendBcc(emailProps))
                {
                    MessageBox.Show("Email(s) sent!");
                }
                else
                {
                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                }
                //<-----
                this.Cursor = oldCursor;

                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MT_tsmiMTreplyIA_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_MTreplyIA, null, null, det, AuditeeRole.Id, PHolder.Id))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Publish Actions to IA. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
            FIHeader header = FIHeader.Select(false, new List<FIDetail>() { det }).First();
            int MTtoIA_counter = FIDetailActivity.howManyPublishesFromMTtoIA(det.Id, this.PHolder.Id);

            if (Migration.migrationMode == false && header.FICategory.NeedsAttachment && MTtoIA_counter < 1) //K.E. 1, 2 - NeedsAttachment && first publication
            {                
                if (fileNames.Length < 1)
                {
                    MessageBox.Show("Please attach a file first! \r\nHeader category: [" + header.FICategory.Name + "] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(2);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.Placeholders = this.PHolder;

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments                
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");

                Cursor oldCursor = this.Cursor; 
                this.Cursor = Cursors.WaitCursor;
                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                AuditOwners iaOwners = FIDetail.getAuditOwners(det.Id);
                emailProps.Recipients = iaOwners.getRecipients(false);
                emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                if (Email.SendBcc(emailProps))
                {
                    MessageBox.Show("Email(s) sent!");
                }
                else
                {
                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                }
                //<-----
                this.Cursor = oldCursor;

                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private void IA_tsmiIAreturnMT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_IAreturnMT, null, null, det))
            {
                return;
            }

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(3);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;

            bool success = true;

            if (det.Placeholders.Count >= 1 && det.Placeholders[0] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[0].Id).User; //det.CurrentOwner1.User;
                detActivity.Placeholders = det.Placeholders[0];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                    emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                    //if (Email.SendBcc(emailProps))
                    //{
                    //    MessageBox.Show("Email(s) sent!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Emails have not been sent!");
                    //}
                    //<-----

                    //create alerts
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + "." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 2 && det.Placeholders[1] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[1].Id).User; //det.CurrentOwner2.User;
                detActivity.Placeholders = det.Placeholders[1];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                    emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                    //if (Email.SendBcc(emailProps))
                    //{
                    //    MessageBox.Show("Email(s) sent!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Emails have not been sent!");
                    //}
                    //<-----

                    //create alerts
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 3 && det.Placeholders[2] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[2].Id).User; //det.CurrentOwner3.User;
                detActivity.Placeholders = det.Placeholders[2];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                    emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                    //if (Email.SendBcc(emailProps))
                    //{
                    //    MessageBox.Show("Email(s) sent!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Emails have not been sent!");
                    //}
                    //<-----

                    //create alerts
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            if (success)
            {
                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts - no need to check if there are attachments or not...
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");
                Close(); //or stay and refresh   
            }

        }
        */
        /*
        private void IA_tsmiIAacceptedMT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_IAacceptMT, null, null, det))
            {
                return;
            }

            if (FIDetail.Finalize(det.Id))
            {
                ChangeLog.Insert(new FIDetail() { Id = det.Id, IsFinalized = det.IsFinalized }, new FIDetail() { Id = det.Id, IsFinalized = true }, "FIDetail");
            }
            else
            {
                MessageBox.Show("The Finalization was not successful!");
                return;
            }

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(12);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;

            bool success = true;

            if (det.Placeholders.Count >= 1 && det.Placeholders[0] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[0].Id).User; //det.CurrentOwner1.User;
                detActivity.Placeholders = det.Placeholders[0];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Don't send email for this action
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (det.Placeholders.Count >= 2 && det.Placeholders[1] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[1].Id).User; //det.CurrentOwner2.User;
                detActivity.Placeholders = det.Placeholders[1];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Don't send email for this action
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 3 && det.Placeholders[2] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[2].Id).User; //det.CurrentOwner3.User;
                detActivity.Placeholders = det.Placeholders[2];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Don't send email for this action
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts - no need to check if there are attachments or not...
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");
                Close(); //or stay and refresh   
            }

        }
        */

        private void MT_tsmiMTdelegateDT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_MTdelegateDT, null, null, det, AuditeeRole.Id, PHolder.Id))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Delegate Actions to Key Users. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            //show selector (form)
            DelegateesSelect frmDTselector = new DelegateesSelect(det.Id, PHolder.Id);
            if (frmDTselector.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //frmDTselector.usrId
            if (Owners_DT.Insert(det.Id, PHolder.Id, frmDTselector.usrId) == false)
            {
                MessageBox.Show("The Detail has not been delegated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                                 
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(5);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.ToUser = new Users(frmDTselector.usrId);
            detActivity.Placeholders = PHolder;

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments
                string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");

                Cursor oldCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                if (Email.SendBcc(emailProps))
                {
                    MessageBox.Show("Email(s) sent!");
                }
                else
                {
                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                }
                //<-----
                this.Cursor = oldCursor;

                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MT_tsmiMTreplyDT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_MTreplyDT, null, null, det, AuditeeRole.Id, PHolder.Id))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Reply to Key Users. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            //get owners_dt
            List<Users> OwnersDT = Owners_DT.GetOwnerDTUsersList(this.det.Id, PHolder.Id);

            if (OwnersDT.Count <= 0)
            {
                MessageBox.Show("The Detail has not been delegated! \r\nPlease delegate it to a Key User first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DelegateesSelect frmDTselector = new DelegateesSelect(OwnersDT);

            Users activityTo = activityTo = OwnersDT[0]; //1st
                       
            if (OwnersDT.Count > 1)
            {
                //if more than one dt - select one key user from list 
                MessageBox.Show("There are more than one Key Users. Please select a key user to reply.");
                if (frmDTselector.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                activityTo = new Users(frmDTselector.usrId);
            }                     

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(7);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.ToUser = activityTo;
            detActivity.Placeholders = PHolder;

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments
                string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");

                Cursor oldCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                if (Email.SendBcc(emailProps))
                {
                    MessageBox.Show("Email(s) sent!");
                }
                else
                {
                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                }
                //<-----
                this.Cursor = oldCursor;

                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DT_tsmiDTreplyMT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_DTreplyMT, null, null, det, AuditeeRole.Id, PHolder.Id))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Reply to Management Team. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(6);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(PHolder.Id).User; //current for this pholder
            detActivity.Placeholders = PHolder;

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments
                string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");

                Cursor oldCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                if (Email.SendBcc(emailProps))
                {
                    MessageBox.Show("Email(s) sent!");
                }
                else
                {
                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                }
                //<-----
                this.Cursor = oldCursor;

                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MT_tsmiMTextendIA_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_MTextendIA, null, null, det, AuditeeRole.Id, PHolder.Id))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Request Deadline Extension. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            DeadlineExtension frmDeadlineExtension = new DeadlineExtension(det.ActionDt, det.Id);
            if (frmDeadlineExtension.ShowDialog() != DialogResult.OK)
            {
                return;
            }                       

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(8);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.Placeholders = PHolder;
            detActivity.ActionDt = frmDeadlineExtension.newActionDate;

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments
                string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");

                Cursor oldCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                AuditOwners iaOwners = FIDetail.getAuditOwners(det.Id);
                emailProps.Recipients = iaOwners.getRecipients(false);
                emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                if (Email.SendBcc(emailProps))
                {
                    MessageBox.Show("Email(s) sent!");
                }
                else
                {
                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                }
                //<-----
                this.Cursor = oldCursor;

                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void IA_tsmiIAextendMT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_IAextendMT, null, null, det))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Extend Deadline. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            DeadlineExtension frmDeadlineExtension = new DeadlineExtension(det.ActionDt, det.Id);
            if(frmDeadlineExtension.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (FIDetail.UpdateActionDate(det.Id, frmDeadlineExtension.newActionDate) == false)
            {
                MessageBox.Show("Update of Action Date was not successful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ChangeLog.Insert(new FIDetail() { Id =det.Id, ActionDt = det.ActionDt }, new FIDetail() { Id = det.Id, ActionDt = frmDeadlineExtension.newActionDate }, "FIDetail");
            }

            dtpDetail_ActionDate.Value = frmDeadlineExtension.newActionDate;

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(10);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.ActionDt = frmDeadlineExtension.newActionDate;

            bool success = true;

            if (det.Placeholders.Count >= 1 && det.Placeholders[0] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[0].Id).User; //det.CurrentOwner1.User;
                detActivity.Placeholders = det.Placeholders[0];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Don't send email for this action

                    //create alerts
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 2 && det.Placeholders[1] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[1].Id).User; //det.CurrentOwner2.User;
                detActivity.Placeholders = det.Placeholders[1];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Don't send email for this action

                    //create alerts
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 3 && det.Placeholders[2] != null)
            {
                detActivity.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[2].Id).User; //det.CurrentOwner3.User;
                detActivity.Placeholders = det.Placeholders[2];

                int newActivityId = FIDetailActivity.Insert(detActivity);

                if (newActivityId > -1)
                {
                    //insert attachments
                    string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    if (fileNames.Length > 0)
                    {
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                        {
                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //Don't send email for this action

                    //create alerts
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete attachments from user's drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                MessageBox.Show("The Action completed!");
                Close(); //or stay and refresh
                DialogResult = DialogResult.OK;
            }
        }

        private void IA_tsmiIAjudgeMT_Click(object sender, EventArgs e)
        {
            //1)checks that is AuditOwner or CAE
            //2)checks that he has not voted
            if (!UserAction.IsLegal(Action.Activity_IAjudgeMT, null, null, det))
            {
                return;
            }

            if (rtbComments.Text.Trim() == "")
            {
                MessageBox.Show("You have not filled in comments!");
            }

            if (MessageBox.Show("You are going to Decide on Management Team's Actions. Are you sure?", "Action", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            FICategory fiCat = completeAudit.FIHeaders[0].FICategory;
            List<FIDetailVoting> VotingList = FIDetailVoting.SelectCurrent(det.Id);
            ChiefVoteCause voteCause = FIDetailVoting.doesChiefNeedsToVote(fiCat, VotingList);
            AuditOwners auditorOwners = FIDetail.getAuditOwners(det.Id);
            int auditorRoleId = 0;

            //1st stage - Voting auditor1, 2
            //2nd stage - Voting supervisor / only after aud1, 2
            //3rd stage - Voting chief / only after aud1, 2, sup

            if (auditorOwners.Auditor1.Id == UserInfo.userDetails.Id) //Auditor1
            {
                auditorRoleId = 1;
            }
            else if (auditorOwners.Auditor2.Id == UserInfo.userDetails.Id) //Auditor2
            {
                auditorRoleId = 2;
            }
            else if (auditorOwners.Supervisor.Id == UserInfo.userDetails.Id) //Supervisor
            {
                auditorRoleId = 3;

                if (auditorOwners.Auditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Auditor1.Id) == false)
                {
                    MessageBox.Show("You cannot decide yet! Auditor1 has to decide first.");
                    return;
                }

                if (auditorOwners.Auditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Auditor2.Id) == false)
                {
                    MessageBox.Show("You cannot decide yet! Auditor2 has to decide first.");
                    return;
                }
            }
            else if (UserInfo.roleDetails.Id == 2) //CAE
            {
                auditorRoleId = 4;

                if (voteCause == ChiefVoteCause.None)
                {
                    MessageBox.Show("You do not have to decide!");
                    return;
                }

                if (auditorOwners.Auditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Auditor1.Id) == false)
                {
                    MessageBox.Show("You cannot decide yet! Auditor1 has to decide first.");
                    return;
                }

                if (auditorOwners.Auditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Auditor2.Id) == false)
                {
                    MessageBox.Show("You cannot decide yet! Auditor2 has to decide first.");
                    return;
                }

                if (auditorOwners.Supervisor.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Supervisor.Id) == false)
                {
                    MessageBox.Show("You cannot decide yet! Supervisor has to decide first.");
                    return;
                }
            }
            else //never...
            {
                MessageBox.Show("You are not authorized to perform this action!");
                return;
            }

            bool isApprover = FIDetailVoting.IsUserApprover(auditorRoleId, auditorOwners, det.Id, voteCause);           

            Voting frmVoting = new Voting(VotingList, det.Id, isApprover, fiCat); //, fiCat);
            if (frmVoting.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = frmVoting.act;
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);

            int newActivityId = FIDetailActivity.Insert(detActivity);

            if (newActivityId > -1)
            {
                //insert attachments                
                if (fileNames.Length > 0)
                {
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                //delete drafts
                DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);

                bool insertedSuccessfully = FIDetailVoting.Insert(det.Id, UserInfo.userDetails.Id, auditorRoleId, frmVoting.cla.Id);

                MessageBox.Show("The Action completed!");

                //=======================================================================

                VotingList = FIDetailVoting.SelectCurrent(det.Id);
                voteCause = FIDetailVoting.doesChiefNeedsToVote(fiCat, VotingList);
                isApprover = FIDetailVoting.IsUserApprover(auditorRoleId, auditorOwners, det.Id, voteCause);

                if (isApprover == false) //send email to next auditor
                {
                    EmailProperties emailProps = new EmailProperties();

                    if (auditorRoleId == 1)
                    {                       
                        //a) Send to Auditor2
                        if (auditorOwners.Auditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Auditor2.Id) == false)
                        {
                            emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = auditorOwners.Auditor2.getEmail(), FullName = auditorOwners.Auditor2.FullName } }; 
                            emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                            emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                            //13, 14, 15, 17
                        }
                        //b) Send to Supervisor
                        else if (auditorOwners.Supervisor.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Supervisor.Id) == false)
                        {
                            emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = auditorOwners.Supervisor.getEmail(), FullName = auditorOwners.Supervisor.FullName } }; 
                            emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                            emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                            //13, 14, 15, 17

                            FIDetailActivity detFSActivity = new FIDetailActivity();
                            detFSActivity.DetailId = det.Id;
                            detFSActivity.ActivityDescription = new ActivityDescription(18);

                            detFSActivity.FromUser = detActivity.FromUser;
                            detFSActivity.ToUser = auditorOwners.Supervisor;

                            FIDetailActivity.Insert(detFSActivity);
                        }
                        //c) send to C.A.E.
                        else if (voteCause != ChiefVoteCause.None)
                        {
                            Users cae = Users.getCAE();

                            FIDetailActivity detFCActivity = new FIDetailActivity();
                            detFCActivity.DetailId = det.Id;
                            //detFCActivity.ActivityDescription = new ActivityDescription(19);
                            if (voteCause == ChiefVoteCause.High_Risk)
                            {
                                detFCActivity.ActivityDescription = new ActivityDescription(23);
                            }
                            else if (voteCause == ChiefVoteCause.Low_Risk_AltNo)
                            {
                                detFCActivity.ActivityDescription = new ActivityDescription(24);
                            }
                            else if(voteCause == ChiefVoteCause.Different_Decisions)
                            {
                                detFCActivity.ActivityDescription = new ActivityDescription(25);
                            }

                            detFCActivity.FromUser = detActivity.FromUser;
                            detFCActivity.ToUser = cae;

                            FIDetailActivity.Insert(detFCActivity);
                                                        
                            emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = cae.getEmail(), FullName = cae.FullName } };
                            emailProps.Subject = detFCActivity.ActivityDescription.EmailSubject;
                            emailProps.Body = detFCActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                            //23 High, 24 Low, 25 Diff                            
                        }                        
                    }
                    else if (auditorRoleId == 2)
                    {
                        //a) Send to Auditor1 
                        if (auditorOwners.Auditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Auditor1.Id) == false)
                        {                            
                            emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = auditorOwners.Auditor1.getEmail(), FullName = auditorOwners.Auditor1.FullName } };
                            emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                            emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                            //13, 14, 15, 17
                        }
                        //b) Send to Supervisor 
                        else if (auditorOwners.Supervisor.Id > 0 && FIDetailVoting.HasAlreadyVoted(det.Id, auditorOwners.Supervisor.Id) == false)
                        {
                            emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = auditorOwners.Supervisor.getEmail(), FullName = auditorOwners.Supervisor.FullName } };
                            emailProps.Subject = detActivity.ActivityDescription.EmailSubject;
                            emailProps.Body = detActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                            //13, 14, 15, 17

                            FIDetailActivity detFSActivity = new FIDetailActivity();
                            detFSActivity.DetailId = det.Id;
                            detFSActivity.ActivityDescription = new ActivityDescription(18);

                            detFSActivity.FromUser = detActivity.FromUser;
                            detFSActivity.ToUser = auditorOwners.Supervisor;

                            FIDetailActivity.Insert(detFSActivity);
                        }
                        //c) send to C.A.E.
                        else if (voteCause != ChiefVoteCause.None)
                        {
                            Users cae = Users.getCAE();

                            FIDetailActivity detFCActivity = new FIDetailActivity();
                            detFCActivity.DetailId = det.Id;
                            //detFCActivity.ActivityDescription = new ActivityDescription(19);
                            if (voteCause == ChiefVoteCause.High_Risk)
                            {
                                detFCActivity.ActivityDescription = new ActivityDescription(23);
                            }
                            else if (voteCause == ChiefVoteCause.Low_Risk_AltNo)
                            {
                                detFCActivity.ActivityDescription = new ActivityDescription(24);
                            }
                            else if (voteCause == ChiefVoteCause.Different_Decisions)
                            {
                                detFCActivity.ActivityDescription = new ActivityDescription(25);
                            }

                            detFCActivity.FromUser = detActivity.FromUser;
                            detFCActivity.ToUser = cae;

                            FIDetailActivity.Insert(detFCActivity);
                                                        
                            emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = cae.getEmail(), FullName = cae.FullName } };
                            emailProps.Subject = detFCActivity.ActivityDescription.EmailSubject;
                            emailProps.Body = detFCActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                            //23, 24, 25                            
                        }
                    }
                    else if (auditorRoleId == 3)
                    {
                        Users cae = Users.getCAE();

                        FIDetailActivity detFCActivity = new FIDetailActivity();
                        detFCActivity.DetailId = det.Id;
                        //detFCActivity.ActivityDescription = new ActivityDescription(19);
                        if (voteCause == ChiefVoteCause.High_Risk)
                        {
                            detFCActivity.ActivityDescription = new ActivityDescription(23);
                        }
                        else if (voteCause == ChiefVoteCause.Low_Risk_AltNo)
                        {
                            detFCActivity.ActivityDescription = new ActivityDescription(24);
                        }
                        else if (voteCause == ChiefVoteCause.Different_Decisions)
                        {
                            detFCActivity.ActivityDescription = new ActivityDescription(25);
                        }

                        detFCActivity.FromUser = detActivity.FromUser;
                        detFCActivity.ToUser = cae;

                        FIDetailActivity.Insert(detFCActivity);

                        //a) send to C.A.E. always (i am not approver)
                        //voteCause                        
                        emailProps.Recipients = new List<Recipient>() { new Recipient() { Email = cae.getEmail(), FullName = cae.FullName } };
                        emailProps.Subject = detFCActivity.ActivityDescription.EmailSubject;
                        emailProps.Body = detFCActivity.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                        //23, 24, 25                        
                    }

                    Cursor oldCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    if (Email.SendBcc(emailProps))
                    {
                        MessageBox.Show("Email(s) sent!");
                    }
                    else
                    {
                        MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                    }
                    this.Cursor = oldCursor;
                }
                else // isApprover - actions (accept (close)/ return to MT)
                {
                    //cae - his decision, au1,2, sup - 3,4,5 && (Completed || Return)
                    Classification strongestClassification = new Classification(); // 4); //return
                    strongestClassification = frmVoting.cla; //always last decision is the strongest!!!

                    //if (auditorRoleId == 1) //au1
                    //{
                    //}
                    //else if (auditorRoleId == 2) //au2
                    //{
                    //}
                    //else if (auditorRoleId == 3) //sup
                    //{
                    //}
                    //else if (auditorRoleId == 4) //cae
                    //{                        
                    //}

                    if (strongestClassification.Decision.Id == 1) //accept
                    {
                        if (FIDetail.Finalize(det.Id))
                        {
                            ChangeLog.Insert(new FIDetail() { Id = det.Id, IsFinalized = det.IsFinalized }, new FIDetail() { Id = det.Id, IsFinalized = true }, "FIDetail");
                        }
                        else
                        {
                            MessageBox.Show("The Finalization was not successful!");
                            return;
                        }

                        FIDetailActivity detActivityAcc = new FIDetailActivity();
                        detActivityAcc.DetailId = det.Id;

                        if (auditorRoleId == 1 || auditorRoleId == 2) //auditor1, 2
                        {
                            detActivityAcc.ActivityDescription = new ActivityDescription(20);
                        }
                        else if (auditorRoleId == 3) //supervisor
                        {
                            detActivityAcc.ActivityDescription = new ActivityDescription(21);
                        }
                        else if (auditorRoleId == 4) //cae
                        {
                            detActivityAcc.ActivityDescription = new ActivityDescription(22);
                        }

                        DialogResult commDr = MessageBox.Show("Do you want your comments and attachments to be published to Managment Teams?", "Comments", MessageBoxButtons.YesNo);

                        if (commDr == DialogResult.Yes)
                        {
                            //detActivityAcc.ActivityDescription = new ActivityDescription(12);
                            detActivityAcc.CommentRtf = detActivity.CommentRtf; //copy from last action
                            detActivityAcc.CommentText = detActivity.CommentText; //copy from last action
                        }

                        bool success = true;

                        if (det.Placeholders.Count >= 1 && det.Placeholders[0] != null)
                        {
                            detActivityAcc.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[0].Id).User; //det.CurrentOwner1.User;
                            detActivityAcc.Placeholders = det.Placeholders[0];

                            int newAccActivityId = FIDetailActivity.Insert(detActivityAcc);

                            if (newAccActivityId > -1)
                            {
                                if (commDr == DialogResult.Yes)
                                {
                                    //insert attachments //copy from last action
                                    string[] fileNamesAcc = ActivityAttachments.getSavedAttachments(newActivityId);
                                    if (fileNamesAcc.Length > 0)
                                    {
                                        if (ActivityAttachments.CopyActivityAttachedFiles(newActivityId, newAccActivityId) == false) //copy from last action
                                        {
                                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                //Don't send email for this action
                            }
                            else
                            {
                                success = false;
                                MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivityAcc.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (det.Placeholders.Count >= 2 && det.Placeholders[1] != null)
                        {
                            detActivityAcc.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[1].Id).User; //det.CurrentOwner2.User;
                            detActivityAcc.Placeholders = det.Placeholders[1];

                            int newAccActivityId = FIDetailActivity.Insert(detActivityAcc);

                            if (newAccActivityId > -1)
                            {
                                if (commDr == DialogResult.Yes)
                                {
                                    //insert attachments //copy from last action
                                    string[] fileNamesAcc = ActivityAttachments.getSavedAttachments(newActivityId);
                                    if (fileNamesAcc.Length > 0)
                                    {
                                        if (ActivityAttachments.CopyActivityAttachedFiles(newActivityId, newAccActivityId) == false) //copy from last action
                                        {
                                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                //Don't send email for this action
                            }
                            else
                            {
                                success = false;
                                MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivityAcc.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (det.Placeholders.Count >= 3 && det.Placeholders[2] != null)
                        {
                            detActivityAcc.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[2].Id).User; //det.CurrentOwner3.User;
                            detActivityAcc.Placeholders = det.Placeholders[2];

                            int newAccActivityId = FIDetailActivity.Insert(detActivityAcc);

                            if (newAccActivityId > -1)
                            {
                                if (commDr == DialogResult.Yes)
                                {
                                    //insert attachments //copy from last action
                                    string[] fileNamesAcc = ActivityAttachments.getSavedAttachments(newActivityId);
                                    if (fileNamesAcc.Length > 0)
                                    {
                                        if (ActivityAttachments.CopyActivityAttachedFiles(newActivityId, newAccActivityId) == false) //copy from last action
                                        {
                                            MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                //Don't send email for this action
                            }
                            else
                            {
                                success = false;
                                MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivityAcc.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (success)
                        {
                            MessageBox.Show("The Action completed!");
                            Close(); //or stay and refresh
                            DialogResult = DialogResult.OK;
                        }
                    }
                    if (strongestClassification.Decision.Id == 2) //return
                    {
                        FIDetailActivity detActivityRet = new FIDetailActivity();
                        detActivityRet.DetailId = det.Id;
                        detActivityRet.ActivityDescription = new ActivityDescription(3);
                        detActivityRet.CommentRtf = detActivity.CommentRtf; //copy from last action
                        detActivityRet.CommentText = detActivity.CommentText; //copy from last action

                        bool success = true;

                        if (det.Placeholders.Count >= 1 && det.Placeholders[0] != null)
                        {
                            detActivityRet.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[0].Id).User; //det.CurrentOwner1.User;
                            detActivityRet.Placeholders = det.Placeholders[0];

                            int newRetActivityId = FIDetailActivity.Insert(detActivityRet);

                            if (newRetActivityId > -1)
                            {
                                //insert attachments //copy from last action
                                string[] fileNamesRet = ActivityAttachments.getSavedAttachments(newActivityId);
                                if (fileNamesRet.Length > 0)
                                {
                                    if (ActivityAttachments.CopyActivityAttachedFiles(newActivityId, newRetActivityId) == false) //copy from last action
                                    {
                                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                Cursor oldCursor = this.Cursor;
                                this.Cursor = Cursors.WaitCursor;
                                //send email
                                //----->
                                EmailProperties emailProps = new EmailProperties();
                                                               
                                //emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivityRet.ToUser.FullName, Email = detActivityRet.ToUser.getEmail() } };
                                //send to auditor1, 2, Supervisor too
                                List<Recipient> ReciList = new List<Recipient>();
                                ReciList = auditorOwners.getRecipients(true);
                                ReciList.Add(new Recipient() { FullName = detActivityRet.ToUser.FullName, Email = detActivityRet.ToUser.getEmail() });
                                emailProps.Recipients = ReciList;

                                emailProps.Subject = detActivityRet.ActivityDescription.EmailSubject;
                                emailProps.Body = detActivityRet.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                                if (Email.SendBcc(emailProps))
                                {
                                    MessageBox.Show("Email(s) sent!");
                                }
                                else
                                {
                                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                                }
                                //<-----
                                this.Cursor = oldCursor;

                                //create alerts
                            }
                            else
                            {
                                success = false;
                                MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivityRet.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (det.Placeholders.Count >= 2 && det.Placeholders[1] != null)
                        {
                            detActivityRet.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[1].Id).User; //det.CurrentOwner2.User;
                            detActivityRet.Placeholders = det.Placeholders[1];

                            int newRetActivityId = FIDetailActivity.Insert(detActivityRet);

                            if (newRetActivityId > -1)
                            {
                                //insert attachments //copy from last action
                                string[] fileNamesRet = ActivityAttachments.getSavedAttachments(newActivityId);
                                if (fileNamesRet.Length > 0)
                                {
                                    if (ActivityAttachments.CopyActivityAttachedFiles(newActivityId, newRetActivityId) == false) //copy from last action
                                    {
                                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                Cursor oldCursor = this.Cursor;
                                this.Cursor = Cursors.WaitCursor;
                                //send email
                                //----->
                                EmailProperties emailProps = new EmailProperties();
                                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivityRet.ToUser.FullName, Email = detActivityRet.ToUser.getEmail() } };
                                emailProps.Subject = detActivityRet.ActivityDescription.EmailSubject;
                                emailProps.Body = detActivityRet.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                                if (Email.SendBcc(emailProps))
                                {
                                    MessageBox.Show("Email(s) sent!");
                                }
                                else
                                {
                                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                                }
                                //<-----
                                this.Cursor = oldCursor;

                                //create alerts
                            }
                            else
                            {
                                success = false;
                                MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivityRet.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (det.Placeholders.Count >= 3 && det.Placeholders[2] != null)
                        {
                            detActivityRet.ToUser = Owners_MT.GetCurrentOwnerMT(det.Placeholders[2].Id).User; //det.CurrentOwner3.User;
                            detActivityRet.Placeholders = det.Placeholders[2];

                            int newRetActivityId = FIDetailActivity.Insert(detActivityRet);

                            if (newRetActivityId > -1)
                            {
                                //insert attachments //copy from last action
                                string[] fileNamesRet = ActivityAttachments.getSavedAttachments(newActivityId);
                                if (fileNamesRet.Length > 0)
                                {
                                    if (ActivityAttachments.CopyActivityAttachedFiles(newActivityId, newRetActivityId) == false) //copy from last action
                                    {
                                        MessageBox.Show("Attached files have not been saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                Cursor oldCursor = this.Cursor;
                                this.Cursor = Cursors.WaitCursor;
                                //send email
                                //----->
                                EmailProperties emailProps = new EmailProperties();
                                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivityRet.ToUser.FullName, Email = detActivityRet.ToUser.getEmail() } };
                                emailProps.Subject = detActivityRet.ActivityDescription.EmailSubject;
                                emailProps.Body = detActivityRet.ActivityDescription.EmailBody.Replace("@", FIDetail.getEmailMessageInfo(det.Id));
                                if (Email.SendBcc(emailProps))
                                {
                                    MessageBox.Show("Email(s) sent!");
                                }
                                else
                                {
                                    MessageBox.Show("Emails have not been sent! \r\nEmails will be sent as soon as the system becomes available again.");
                                }
                                //<-----
                                this.Cursor = oldCursor;

                                //create alerts
                            }
                            else
                            {
                                success = false;
                                MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivityRet.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (success)
                        {
                            MessageBox.Show("The Action completed!");
                            Close(); //or stay and refresh
                            DialogResult = DialogResult.OK;
                        }

                    }

                    FIDetailVoting.UpdatePackAndCurrentFlags(det.Id);
                }
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
            DialogResult = DialogResult.OK; //???
        }

        private void MIcopy_Click(object sender, EventArgs e)
        {
            /*
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {

                //if (rtbComments.Text.Trim() != "")   //|| attFNames.Length > 0
                //{
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to replace your comments and attached files with selected record's comments and files?", "Copy comments and attachend files", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
                //}

                //string commText = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["CommentText"]).ToString();
                string commRtf = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["CommentRtf"]).ToString();

                //rtbComments.Text = commText;
                rtbComments.Rtf = commRtf; //send fonts with text 

                //------------------

                int activityId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                string[] attFNames = ActivityAttachments.getSavedAttachments(activityId);

                if (attFNames.Length > 0)
                {
                    if (DraftAttachments.InsertDraftsAttachedFilesFromActivity(activityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been copied!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            */
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id); //delete old
            FIDetailActivity.saveDraftRtf(det.Id, PHolder.Id, rtbComments.Rtf, rtbComments.Text); //insert new
        }

        private void FIActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (rtbComments.Rtf != FIDetailActivity.getDraftRtf(det.Id, PHolder.Id, UserInfo.userDetails.Id))
            if (rtbComments.Text != FIDetailActivity.getDraftText(det.Id, PHolder.Id, UserInfo.userDetails.Id))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes on comments to Drafts?", "Save comments", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id); //delete old
                    if (rtbComments.Text.Trim() != "")
                    {
                        FIDetailActivity.saveDraftRtf(det.Id, PHolder.Id, rtbComments.Rtf, rtbComments.Text); //insert new
                    }
                }
            }

        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            //int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());

            //int draftId = FIDetailActivity.getDraftId(det.Id, PHolder.Id, UserInfo.userDetails.Id);

            DraftAttachments attachedFiles = new DraftAttachments(det.Id, PHolder.Id, UserInfo.userDetails.Id);

            //if (!UserAction.IsLegal(Action.Activity_Attach, thisAudit))
            //{
            //    attachedFiles.makeReadOnly();
            //}

            attachedFiles.ShowDialog();

            //if (attachedFiles.success)
            //{
                ////refresh
                //int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                //auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                //gridControl1.DataSource = auditBList; //DataSource
                //int rowHandle = gridView1.GetRowHandle(index);
                //gridView1.FocusedRowHandle = rowHandle;
            //}


        }

        private void MIattachments_Click(object sender, EventArgs e)
        {
            int ActivityId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());

            ActivityAttachments attachedFiles = new ActivityAttachments(ActivityId);
            attachedFiles.ShowDialog();

        }

        private void MIcopyComments_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                //if (rtbComments.Text.Trim() != "")   
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to replace your comments with selected record's comments?", "Copy comments", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                string commRtf = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["CommentRtf"]).ToString();
                rtbComments.Rtf = commRtf; //send fonts with text                 
            }
        }

        private void MIcopyAttachments_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                //if (rtbComments.Text.Trim() != "")   //|| attFNames.Length > 0
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to replace your attached files with selected record's files?", "Copy attached files", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                int activityId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                string[] attFNames = ActivityAttachments.getSavedAttachments(activityId);

                if (attFNames.Length > 0)
                {
                    if (DraftAttachments.InsertDraftsAttachedFilesFromActivity(activityId, det.Id, this.PHolder.Id) == false)
                    {
                        MessageBox.Show("Attached files have not been copied!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MIexportAllToExcel_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                DialogResult result = sfd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    gridControl1.ExportToXlsx(sfd.FileName);
                }
            }
        }

        private void MIadminChangeFont_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int activityId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                string rtf = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["CommentRtf"]).ToString();

                RichTextBox rtbTemp = new RichTextBox();
                rtbTemp.Rtf = rtf;
                //MessageBox.Show("OldRtf: " + rtbTemp.Rtf);
                rtbTemp.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12, FontStyle.Regular);
                //MessageBox.Show("NewRtf: " + rtbTemp.Rtf);
                //MessageBox.Show("Text: " + rtbTemp.Text);

                System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(SqlDBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[FIDetail_Activity] SET CommentRtf = encryptByPassPhrase(@passPhrase, convert(varchar(7800), @CommentRtf)) WHERE Id = @ActivityId ";

                try
                {
                    sqlConn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(UpdSt, sqlConn);

                    cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                    cmd.Parameters.AddWithValue("@ActivityId", activityId);
                    
                    if (rtbTemp.Text.Trim() == "")
                    {
                        cmd.Parameters.AddWithValue("@CommentRtf", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CommentRtf", rtbTemp.Rtf);
                    }
                                        
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);

                }
                sqlConn.Close();

                MessageBox.Show("Done!");
            }
        }
    }
}
