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

        public Voting(int givenDetailId, FICategory givenFICategory)
        {
            InitializeComponent();

            fiCat = givenFICategory;
            txtCategory.Text = fiCat.Name;

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

            tsStatusLblUser.Text = "Role: " + choosenRole;
        }

        FICategory fiCat = new FICategory();



    }
}
