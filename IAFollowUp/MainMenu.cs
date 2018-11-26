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

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frmChangePass = new ChangePassword(user);
            frmChangePass.ShowDialog();

            if (frmChangePass.successfullyChangedPassword == false)
            {
                return;
            }
        }

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

        private void auditViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //View Audits...
        }

        private void insertNewAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Audit_Create))
            {
                //InsertNewAudit frmInsertNewAudit = new InsertNewAudit();
                //frmInsertNewAudit.ShowDialog();
            }
        }
    }
}
