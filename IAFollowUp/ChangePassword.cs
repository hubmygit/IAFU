using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(User userDetails)
        {
            InitializeComponent();

            txtUserName.Text = userDetails.UserName;
            lblFullName.Text = userDetails.FullName;

            thisUser = userDetails;

            successfullyChangedPassword = false;
        }

        public User thisUser = new User();
        public bool successfullyChangedPassword;
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!UserInfo.checkPassword(txtUserName.Text, txtOldPassword.Text))//OldPassOk
            {
                MessageBox.Show("Old Password is not correct!");
                return;
            }

            if (txtNewPassword.Text != txtNewPassword2.Text)//SamePasswords
            {
                MessageBox.Show("New Passwords don't match!");
                return;
            }

            List<PasswordHistory> LastThreePasswords = UserInfo.get_passwordHistoryLastThreeDetails(thisUser.Id);
            //string aaaa = Encrypt("QWERTY12345!").ToString();
            //if (LastThreePasswords.Exists(i => i.Password == txtNewPassword.Text))//LastThreePasswords
            //if (LastThreePasswords.Exists(i => i.Password == Encrypt(txtNewPassword.Text).ToString()))//LastThreePasswords

            byte[] HashPass = Encrypt(txtNewPassword.Text);

            if (LastThreePasswords.Exists(i => i.Pass.SequenceEqual(HashPass)))//LastThreePasswords
            {
                MessageBox.Show("New Password must be different than your last 3 passwords!");
                return;
            }

            if (txtNewPassword.Text == txtUserName.Text)
            {
                MessageBox.Show("New Password must be different than your Username!");
                return;
            }

            if (!IsStrongPass(txtNewPassword.Text)) //PassedCriteria
            {
                MessageBox.Show("Your Password must contain an uppercase letter, a digit and a special character and must meet the minimum of 8 characters length!");
                return;
            }


            //update
            if (update_PasswordHistory_Table(LastThreePasswords.Where(i => i.IsCurrent == true).First().Id, false))
            {
                //insert 
                if (!insertInto_PasswordHistory_Table(UserInfo.userDetails.Id, HashPass)) //txtNewPassword.Text))
                {
                    if (update_PasswordHistory_Table(LastThreePasswords.First().Id, true))
                    {
                        MessageBox.Show("There was an error with change of your password. Please use your old Password.");
                    }
                    else
                    {
                        MessageBox.Show("There was an error with change of your password.");
                    }
                }
                else
                {
                    MessageBox.Show("Your Password has been changed successfully!");
                    successfullyChangedPassword = true;
                }
            }

            Close();

        }

        public bool update_PasswordHistory_Table(int Id, bool IsCurrent)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "UPDATE [dbo].[PasswordHistory] SET IsCurrent = @IsCurrent WHERE Id = @Id";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@IsCurrent", IsCurrent);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            sqlConn.Close();

            return ret;
        }

        public static bool update_PasswordHistory_TableAllRecsPerUser(int UsersId, bool IsCurrent)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "UPDATE [dbo].[PasswordHistory] SET IsCurrent = @IsCurrent WHERE UsersId = @UsersId";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@UsersId", UsersId);
                cmd.Parameters.AddWithValue("@IsCurrent", IsCurrent);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            sqlConn.Close();

            return ret;
        }

        public static bool update_PasswordHistory_EnableLatsPassPerUser(int UsersId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            //string UpdSt = "UPDATE [dbo].[PasswordHistory] SET IsCurrent = 'True' WHERE UsersId = @UsersId ORDER BY ";
            //SELECT Id FROM [dbo].[PasswordHistory] where usersId = 4 order by PassUpdDate desc

            string UpdSt = "UPDATE [dbo].[PasswordHistory] SET IsCurrent = 'True' WHERE Id in ( " +
                " SELECT top (1) Id FROM [dbo].[PasswordHistory] WHERE UsersId = @UsersId ORDER BY PassUpdDate DESC " + ")";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@UsersId", UsersId);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            sqlConn.Close();

            return ret;
        }

        public static bool init_insertInto_PasswordHistory_Table(int UserId, byte[] hashPass)//string Password)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "INSERT INTO [dbo].[PasswordHistory] ([UsersId], [Password], [PassUpdDate], [IsCurrent]) VALUES (@UsersId, @Password, '2000-01-01 01:00:00', 1)";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@UsersId", UserId);
                cmd.Parameters.AddWithValue("@Password", hashPass);//Password);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            sqlConn.Close();

            return ret;
        }

        public static bool insertInto_PasswordHistory_Table(int UserId, byte[] hashPass)//string Password)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "INSERT INTO [dbo].[PasswordHistory] ([UsersId], [Password], [PassUpdDate], [IsCurrent]) VALUES (@UsersId, @Password, getdate(), 1)";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@UsersId", UserId);
                cmd.Parameters.AddWithValue("@Password", hashPass);//Password);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            sqlConn.Close();

            return ret;
        }

        public bool IsStrongPass(string password)
        {
            bool ret = false;

            if (password.Any(char.IsUpper) && password.Any(char.IsDigit) && !password.All(char.IsLetterOrDigit) && password.Length >= 8) //password.Any(char.IsLower);
            {
                ret = true;
            }

            return ret;
        }

        public static byte[] Encrypt(string text)
        {
            byte[] ret = null;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT HASHBYTES('SHA2_512',  @GivenText + @passPhrase) as HashText ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.Add("@GivenText", SqlDbType.VarChar);
                cmd.Parameters["@GivenText"].Value = text;

                cmd.Parameters.Add("@passPhrase", SqlDbType.VarChar);
                cmd.Parameters["@passPhrase"].Value = SqlDBInfo.passPhrase;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = (byte[])reader["HashText"];
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
    }
}
