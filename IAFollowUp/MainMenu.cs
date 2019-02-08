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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public MainMenu(User LogInUser, Role LogInRole)
        {
            InitializeComponent();

            user = LogInUser;
            role = LogInRole;

            UserAuth.ArrangeMenuItems(role, menuStrip);

            tsStatusLblUser.Text = "User: " + UserInfo.userDetails.UserName + " - " + UserInfo.userDetails.FullName;
        }

        public User user = new User();
        public Role role = new Role();
        UserAuthorization UserAuth = new UserAuthorization();

        //help---------->
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frmChangePass = new ChangePassword(user);
            frmChangePass.ShowDialog();

            if (frmChangePass.successfullyChangedPassword == false)
            {
                return;
            }
        }
        //help<----------

        //administrator---------->
        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRole frmNewRole = new CreateRole();
            frmNewRole.ShowDialog();
        }

        private void viewRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRole frmViewRole = new ViewRole();
            frmViewRole.ShowDialog();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser frmCreateUser = new CreateUser();
            frmCreateUser.ShowDialog();
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUser frmViewUser = new ViewUser();
            frmViewUser.ShowDialog();
        }

        private void viewChangeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLogView viewChangeLog = new ChangeLogView();
            viewChangeLog.ShowDialog();
        }

        private void deptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDepartments frmDepts = new ViewDepartments();
            frmDepts.ShowDialog();
        }

        private void manageAuditOwnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAuditAuditors frmChangeAuditors = new ChangeAuditAuditors();
            frmChangeAuditors.ShowDialog();
        }
        //administrator<----------

        //auditors---------->
        private void auditViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Audit_View))
            {
                AuditView frmAuditView = new AuditView();
                //frmAuditView.auditList = frmAuditView.auditList.Where(i => i.IsDeleted == false).ToList();
                frmAuditView.ShowDialog();
            }
        }

        private void insertNewAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Audit_Create))
            {
                AuditInsert frmInsertNewAudit = new AuditInsert();
                frmInsertNewAudit.ShowDialog();
            }
        }

        private void fiAuditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.FI_View))
            {
                FIView_Auditees frmFIViewAuditees = new FIView_Auditees();
                frmFIViewAuditees.ShowDialog();
            }
        }
        //auditors<----------

        //auditees---------->
        private void fiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.FI_View))
            {
                FIView_Auditees frmFIViewAuditees = new FIView_Auditees();
                frmFIViewAuditees.ShowDialog();
            }
        }

        //auditees<----------

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserInfo.UpdateExitDt();
        }

        //temporary to remove....
        private void tmp1Notif_Click(object sender, EventArgs e)
        {
            Notifications.firstNotification();



        }
    }
}
