using System;
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
        
        private void btnMTtoIA_Click(object sender, EventArgs e)
        {
            /*
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(2);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id); 
            
            FIDetailActivity.Insert(detActivity);
            */
        }

        private void btnMTtoDT_Click(object sender, EventArgs e)
        {
            /*
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(7);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
            */
        }

        private void btnDTtoMT_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(6);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
        }

        private void btnIAtoMT_Click(object sender, EventArgs e)
        {
            /*
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(3);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
            */
        }

        private void btnMTtoIAInform_Click(object sender, EventArgs e)
        {
            /*
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(4);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);

            FIDetailActivity.Insert(detActivity);
            */
        }

        private void btnMTtoDTDelegate_Click(object sender, EventArgs e)
        {
            /*
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(5);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
            */
        }

        private void btnMTtoIAExtension_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(8);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);

            FIDetailActivity.Insert(detActivity);
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

            if (FIDetailActivity.Insert(detActivity))
            {
                //send email

                //create alerts

                //...?
                MessageBox.Show("The Action completed!");
                Close();

                //delete comments from user's drafts
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

            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = det.Id;
            detActivity.ActivityDescription = new ActivityDescription(2);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            detActivity.Placeholders = this.PHolder;

            if (FIDetailActivity.Insert(detActivity))
            {
                //send email

                //create alerts

                //...?
                MessageBox.Show("The Action completed!");
                Close();

                //delete comments from user's drafts
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
                detActivity.ToUser = det.CurrentOwner1.User;
                detActivity.Placeholders = det.Placeholders[0];

                if (FIDetailActivity.Insert(detActivity))
                {
                    //send email

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
                detActivity.ToUser = det.CurrentOwner2.User;
                detActivity.Placeholders = det.Placeholders[1];

                if (FIDetailActivity.Insert(detActivity))
                {
                    //send email

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
                detActivity.ToUser = det.CurrentOwner3.User;
                detActivity.Placeholders = det.Placeholders[2];

                if (FIDetailActivity.Insert(detActivity))
                {
                    //send email

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
                MessageBox.Show("The Action completed successfully!");
                Close();

                //delete comments from user's drafts
            }

        }

        private void IA_tsmiIAacceptedMT_Click(object sender, EventArgs e)
        {
            if (!UserAction.IsLegal(Action.Activity_IAacceptMT, null, null, det))
            {
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
                detActivity.ToUser = det.CurrentOwner1.User;
                detActivity.Placeholders = det.Placeholders[0];

                if (FIDetailActivity.Insert(detActivity))
                {
                    //send email ??
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 2 && det.Placeholders[1] != null)
            {
                detActivity.ToUser = det.CurrentOwner2.User;
                detActivity.Placeholders = det.Placeholders[1];

                if (FIDetailActivity.Insert(detActivity))
                {
                    //send email ??
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (det.Placeholders.Count >= 3 && det.Placeholders[2] != null)
            {
                detActivity.ToUser = det.CurrentOwner3.User;
                detActivity.Placeholders = det.Placeholders[2];

                if (FIDetailActivity.Insert(detActivity))
                {
                    //send email ??
                }
                else
                {
                    success = false;
                    MessageBox.Show("The Action has not been completed!" + "\r\nDept: " + detActivity.Placeholders.Department.Name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                MessageBox.Show("The Action completed successfully!");
                Close();

                //delete comments from user's drafts
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

            if (FIDetailActivity.Insert(detActivity))
            {
                //send email

                //create alerts

                //...?
                MessageBox.Show("The Action completed!");
                Close();

                //delete comments from user's drafts
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

            if (FIDetailActivity.Insert(detActivity))
            {
                //send email

                //create alerts

                //...?
                MessageBox.Show("The Action completed!");
                Close();

                //delete comments from user's drafts
            }
            else
            {
                MessageBox.Show("The Action has not been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
