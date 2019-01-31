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

            gridControl1.DataSource = new BindingList<FIDetailActivity>(detailActivity);

            //get draft
            rtbComments.Rtf = FIDetailActivity.getDraftRtf(givenDetail.Id, givenPlaceholderId, UserInfo.userDetails.Id);

            if (givenDetail.ActionDt != null)
            {
                dtpDetail_ActionDate.CustomFormat = "dd.MM.yyyy";
                dtpDetail_ActionDate.Value = (DateTime)givenDetail.ActionDt;
            }
        }

        //public int detId;
        public List<FIDetailActivity> detailActivity = new List<FIDetailActivity>();
        public FIDetail det = new FIDetail();

        public Placeholders PHolder = new Placeholders();
        public AuditeesRoles AuditeeRole = new AuditeesRoles();

        public string choosenRole; 

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
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                    {
                        //delete drafts
                        DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    }
                    else
                    {
                        MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                MessageBox.Show("The Action completed!");

                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                AuditOwners iaOwners = FIDetail.getAuditOwners(det.Id);
                emailProps.Recipients = iaOwners.getRecipients();
                emailProps.Subject = "";
                emailProps.Body = "";
                //if (Email.SendBcc(emailProps))
                //{
                //    MessageBox.Show("Email(s) sent!");
                //}
                //else
                //{
                //    MessageBox.Show("Emails have not been sent!");
                //}
                //<-----

                Close(); //or stay and refresh                
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

            string[] fileNames = DraftAttachments.getSavedAttachments(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
            FIHeader header = FIHeader.Select(false, new List<FIDetail>() { det }).First();
            int MTtoIA_counter = FIDetailActivity.howManyPublishesFromMTtoIA(det.Id, this.PHolder.Id);

            if (header.FICategory.NeedsAttachment && MTtoIA_counter < 1) //K.E. 1, 2 - NeedsAttachment && first publication
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
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                    {
                        //delete drafts
                        DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    }
                    else
                    {
                        MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                MessageBox.Show("The Action completed!");

                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                AuditOwners iaOwners = FIDetail.getAuditOwners(det.Id);
                emailProps.Recipients = iaOwners.getRecipients();
                emailProps.Subject = "";
                emailProps.Body = "";
                //if (Email.SendBcc(emailProps))
                //{
                //    MessageBox.Show("Email(s) sent!");
                //}
                //else
                //{
                //    MessageBox.Show("Emails have not been sent!");
                //}
                //<-----

                Close(); //or stay and refresh   
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
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

                MessageBox.Show("The Action completed!");
                Close(); //or stay and refresh   
            }

        }

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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
                    //if (Email.SendBcc(emailProps))
                    //{
                    //    MessageBox.Show("Email(s) sent!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Emails have not been sent!");
                    //}
                    //<-----
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
                    //if (Email.SendBcc(emailProps))
                    //{
                    //    MessageBox.Show("Email(s) sent!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Emails have not been sent!");
                    //}
                    //<-----
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
                    //if (Email.SendBcc(emailProps))
                    //{
                    //    MessageBox.Show("Email(s) sent!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Emails have not been sent!");
                    //}
                    //<-----
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

                MessageBox.Show("The Action completed!");
                Close(); //or stay and refresh   
            }

        }

        private void MT_tsmiMTdelegateDT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_MTdelegateDT, null, null, det, AuditeeRole.Id, PHolder.Id))
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
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                    {
                        //delete drafts
                        DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    }
                    else
                    {
                        MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                MessageBox.Show("The Action completed!");

                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                emailProps.Subject = "";
                emailProps.Body = "";
                //if (Email.SendBcc(emailProps))
                //{
                //    MessageBox.Show("Email(s) sent!");
                //}
                //else
                //{
                //    MessageBox.Show("Emails have not been sent!");
                //}
                //<-----

                Close(); //or stay and refresh   
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

            //get owners_dt
            List<Users> OwnersDT = Owners_DT.GetOwnerDTUsersList(this.det.Id, PHolder.Id);

            DelegateesSelect frmDTselector = new DelegateesSelect(OwnersDT);

            if (OwnersDT.Count <= 0)
            {
                MessageBox.Show("The Detail has not been delegated! \r\nPlease delegate it to a Key User first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OwnersDT.Count > 1)
            {
                //if more than one dt - select one key user from list 
                MessageBox.Show("There are more than one Key Users. Please select a key user to reply.");
                if (frmDTselector.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(7);
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
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                    {
                        //delete drafts
                        DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    }
                    else
                    {
                        MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                MessageBox.Show("The Action completed!");

                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                emailProps.Subject = "";
                emailProps.Body = "";
                //if (Email.SendBcc(emailProps))
                //{
                //    MessageBox.Show("Email(s) sent!");
                //}
                //else
                //{
                //    MessageBox.Show("Emails have not been sent!");
                //}
                //<-----

                Close(); //or stay and refresh   
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
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                    {
                        //delete drafts
                        DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    }
                    else
                    {
                        MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                MessageBox.Show("The Action completed!");

                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                emailProps.Subject = "";
                emailProps.Body = "";
                //if (Email.SendBcc(emailProps))
                //{
                //    MessageBox.Show("Email(s) sent!");
                //}
                //else
                //{
                //    MessageBox.Show("Emails have not been sent!");
                //}
                //<-----

                Close(); //or stay and refresh   
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
                    if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                    {
                        //delete drafts
                        DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                    }
                    else
                    {
                        MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //create alerts

                //delete comments from user's drafts
                FIDetailActivity.deleteDraftRtf(det.Id, PHolder.Id);
                rtbComments.Clear();

                MessageBox.Show("The Action completed!");

                //send email
                //----->
                EmailProperties emailProps = new EmailProperties();
                AuditOwners iaOwners = FIDetail.getAuditOwners(det.Id);
                emailProps.Recipients = iaOwners.getRecipients();
                emailProps.Subject = "";
                emailProps.Body = "";
                //if (Email.SendBcc(emailProps))
                //{
                //    MessageBox.Show("Email(s) sent!");
                //}
                //else
                //{
                //    MessageBox.Show("Emails have not been sent!");
                //}
                //<-----

                Close(); //or stay and refresh   
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
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
                        if (ActivityAttachments.InsertActivityAttachedFilesFromDrafts(newActivityId, det.Id, this.PHolder.Id))
                        {
                            //delete drafts
                            DraftAttachments.Delete_SampleFiles(det.Id, this.PHolder.Id, UserInfo.userDetails.Id);
                        }
                        else
                        {
                            MessageBox.Show("Attached files have not benn saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //send email
                    //----->
                    EmailProperties emailProps = new EmailProperties();
                    emailProps.Recipients = new List<Recipient>() { new Recipient() { FullName = detActivity.ToUser.FullName, Email = detActivity.ToUser.getEmail() } };
                    emailProps.Subject = "";
                    emailProps.Body = "";
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

                MessageBox.Show("The Action completed!");
                Close(); //or stay and refresh   
            }
        }

        private void IA_tsmiIAjudgeMT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_IAjudgeMT, null, null, det))
            {
                return;
            }

            //
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

        
    }
}
