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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            txtUserName.Text = UserInfo.WindowsUser;
            lblFullName.Text = UserInfo.userDetails.FullName;

            LoggedIn = false;
        }

        public bool LoggedIn;
        public User user = new User();
        public Role role = new Role();
        public int failedLoginAttempts = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            RunOn_TxtUserName_Leave();

            if (UserInfo.checkPassword(txtUserName.Text, txtPassword.Text))
            {
                UserInfo.roleDetails = UserInfo.get_roleDetails(UserInfo.userDetails.RolesId);

                toolStripMess.Text = "";

                //check expiration date
                if (UserInfo.IsPasswordExpired())
                {
                    MessageBox.Show("Your Password has expired! Please change it.");
                    ChangePassword frmChangePass = new ChangePassword(UserInfo.userDetails);
                    frmChangePass.ShowDialog();

                    if (frmChangePass.successfullyChangedPassword == false)
                    {
                        return;
                    }

                }

                LoggedIn = true;
                user = UserInfo.userDetails;
                role = UserInfo.roleDetails;

                UserInfo.Insert_AppLogIn();

                Close();

            }
            else
            {
                toolStripMess.ForeColor = Color.Red;
                toolStripMess.Text = "Not authorized user!";

                failedLoginAttempts++;
                toolStripMess.Text += " [Attempt(s) " + failedLoginAttempts.ToString() + " of 5]";

                if (failedLoginAttempts == 5)
                {
                    MessageBox.Show("You reached the maximum number of failed attempts to log in!");

                    //disable User (if exists)
                    //---------------------
                    int usrId = UserInfo.getUserId(txtUserName.Text);
                    if (usrId > 0)
                    {
                        ChangePassword.update_PasswordHistory_TableAllRecsPerUser(usrId, false);
                    }
                    //---------------------

                    Close();
                }
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            RunOn_TxtUserName_Leave();
        }

        private void RunOn_TxtUserName_Leave()
        {
            UserInfo.userDetails = UserInfo.get_userDetails(txtUserName.Text);

            if (UserInfo.userDetails.FullName is null || UserInfo.userDetails.FullName == "")
            {
                lblFullName.Text = "";
                toolStripMess.ForeColor = Color.Red;
                toolStripMess.Text = "Not authorized user!";

                UserInfo.IsAuthorized = false;
            }
            else
            {
                lblFullName.Text = UserInfo.userDetails.FullName;
                toolStripMess.Text = "";

                UserInfo.IsAuthorized = true;
            }
        }
    }
}
