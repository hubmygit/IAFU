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
    public partial class Voting : Form
    {
        public Voting()
        {
            InitializeComponent();
        }

        public Voting(List<FIDetailVoting> givenFIDetailVotingList, int givenDetailId, bool givenIsApprover, FICategory givenFICategory) 
        {
            InitializeComponent();

            fiCat = givenFICategory;
            //txtCategory.Text = fiCat.Name;

            detailVotingList = givenFIDetailVotingList;

            isApprover = givenIsApprover;

            gridControl1.DataSource = new BindingList<FIDetailVoting>(givenFIDetailVotingList);

            //Chief Audit Executive
            //Auditors (1, 2, Supervisor)

            string choosenRole = UserInfo.roleDetails.Name; //Auditors or CAE

            AuditOwners auditorOwners = FIDetail.getAuditOwners(givenDetailId);

            if (UserInfo.roleDetails.Id == 3)//Auditors
            {
                if (auditorOwners.Auditor1.Id == UserInfo.userDetails.Id)
                {
                    choosenRole += " (Auditor1)"; //1, 2, Supervisor
                }
                else if (auditorOwners.Auditor2.Id == UserInfo.userDetails.Id)
                {
                    choosenRole += " (Auditor2)"; //1, 2, Supervisor
                }
                else if (auditorOwners.Supervisor.Id == UserInfo.userDetails.Id)
                {
                    choosenRole += " (Supervisor)"; //1, 2, Supervisor
                }
            }
            else if (UserInfo.roleDetails.Id == 2) //CAE
            {
                choosenRole += " (Chief Audit Executive)"; 
            }

            string approver = "Not Approver";
            if (givenIsApprover)
            {
                approver = "Approver";
            }

            tsStatusLblUser.Text = "Role: " + choosenRole + "/" + approver;

            //--------------------------------------------

            //if (auditorOwners.Auditor1.Id > 0)
            //{

            //}
            //else if (auditorOwners.Auditor2.Id > 0)
            //{

            //}
            //else if (auditorOwners.Supervisor.Id > 0)
            //{

            //}
        }

        FICategory fiCat = new FICategory();
        public Decision dec = new Decision();
        public Classification cla = new Classification();
        public ActivityDescription act = new ActivityDescription();
        bool isApprover = false;
        List<FIDetailVoting> detailVotingList = new List<FIDetailVoting>();
        private void btnSave_Click(object sender, EventArgs e)
        {         
            if (rbForwardCompleted.Checked)
            {
                dec = new Decision(1);
                cla = new Classification(1);
                act = new ActivityDescription(13);
            }
            else if (rbForwardAlternative.Checked)
            {
                dec = new Decision(1);
                cla = new Classification(2);
                act = new ActivityDescription(14);
            }
            else if (rbForwardNo.Checked)
            {
                dec = new Decision(1);
                cla = new Classification(3);
                act = new ActivityDescription(15);
            }
            else if (rbReturn.Checked)
            {
                dec = new Decision(2);
                cla = new Classification(4);
                act = new ActivityDescription(17);
            }
            else
            {
                MessageBox.Show("Please select a decision first.");
                return;
            }

            string mess = "Are you sure about your choise?";

            List<FIDetailVoting> newVotingList = detailVotingList.ToList();
            newVotingList.Add(new FIDetailVoting() { Classification = cla });
            ChiefVoteCause newVoteCause = FIDetailVoting.doesChiefNeedsToVote(fiCat, newVotingList);

            if ((isApprover && newVoteCause == ChiefVoteCause.None) || UserInfo.roleDetails.Id == 2)
            {
                mess += "\r\n Be carefoul, by your selection you are the Approver. \r\nYour comments and attachments will be published to Managment Teams.";
            }

            DialogResult dr = MessageBox.Show(mess, "Decision", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }

                
        }
    }
}
