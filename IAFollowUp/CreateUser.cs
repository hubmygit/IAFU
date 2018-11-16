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
    public partial class CreateUser : Form
    {
        public CreateUser() //insert
        {
            InitializeComponent();

            Init();

            isInsert = true;
        }

        public CreateUser(User user) //update
        {
            InitializeComponent();
            Init();

            oldUserRecord = user;

            isInsert = false;
            txtUserName.Text = user.UserName;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            cbRoles.SelectedIndex = cbRoles.FindStringExact(user.Role.Name);

        }
        public void Init()
        {
            cbRoles.Items.AddRange(Role.GetRolesComboboxItemsList(rolesList).ToArray<ComboboxItem>());
        }

        public List<Role> rolesList = ViewRole.SelectRole();

        public bool isInsert = false;
        public bool success = false;
        public User oldUserRecord = new User();
        public User newUserRecord = new User();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a User Name!");
                return;
            }
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Full Name!");
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Email!");
                return;
            }
            if (cbRoles.Text.Trim() == "")
            {
                MessageBox.Show("Please choose a Role!");
                return;
            }

            newUserRecord = new User();

            newUserRecord.Email = txtEmail.Text;
            newUserRecord.FullName = txtFullName.Text;
            newUserRecord.UserName = txtUserName.Text;
            newUserRecord.Role = LibFunctions.getComboboxItem<Role>(cbRoles);
            newUserRecord.RolesId = LibFunctions.getComboboxItem<Role>(cbRoles).Id;


            newUserRecord.Id = oldUserRecord.Id; //update only

            if (isInsert) //insert
            {
                int NewUserId = InsertUser(newUserRecord);
                if (NewUserId > -1)
                {
                    MessageBox.Show("New User inserted successfully!");
                    success = true;

                    string initPass = GetRandomPassword();

                    byte[] HashPass = ChangePassword.Encrypt(initPass);

                    if (ChangePassword.insertInto_PasswordHistory_Table(NewUserId, HashPass))
                    {
                        NewPassword frmNewPass = new NewPassword(initPass);
                        frmNewPass.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error while creating new password!");
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show("The New User has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (UpdateTable_User(newUserRecord))
                {
                    MessageBox.Show("User updated successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The User has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int InsertUser(User user)
        {
            //bool ret = false;
            int ret = -1;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Users] ([UserName],[FullName],[Email] ,[RolesId], [InsDt]) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES " +
                           "(encryptByPassPhrase(@passPhrase, convert(varchar(500), @UserName)), encryptByPassPhrase(@passPhrase, convert(varchar(500), @FullName))," +
                           " encryptByPassPhrase(@passPhrase, convert(varchar(500), @Email)), @RolesId, getdate() )";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@RolesId", user.RolesId);

                cmd.CommandType = CommandType.Text;
                //int rowsAffected = cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();

                //if (rowsAffected > 0)
                //{
                //    ret = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

        //private int InsertPassword(int usersId, string initPassword)
        //{
        //    bool ret = false;

        //    SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
        //    string InsSt = "INSERT INTO [dbo].[PasswordHistory] ([UsersId], [Password], [PassUpdDate], [IsCurrent]) " +
        //                   "VALUES " +
        //                   "(@UsersId, HASHBYTES('SHA2_512',  @Password + @passPhrase), getdate(), 'True' )";
        //    try
        //    {
        //        sqlConn.Open();
        //        SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

        //        cmd.Parameters.AddWithValue("@UsersId", usersId);
        //        cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);                
        //        cmd.Parameters.AddWithValue("@Password", "xxxxxxxxxxxxxxxxxxxxxxxxxxx");

        //        cmd.CommandType = CommandType.Text;
        //        int rowsAffected = cmd.ExecuteNonQuery();

        //        if (rowsAffected > 0)
        //        {
        //            ret = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("The following error occurred: " + ex.Message);

        //    }
        //    sqlConn.Close();

        //    return ret;
        //}

        private bool UpdateTable_User(User user)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Users] SET [UserName] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @UserName)), " +
                "[FullName] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @FullName)), [Email] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Email)) , " +
                "[RolesId] = @RolesId " +
                "WHERE id = @id ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@RolesId", user.RolesId);


                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

        public static string GetRandomPassword()
        {
            string ret = "";

            string[] UpperCaseLetters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int ucMax = 2;

            string[] LowerCaseLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int lcMax = 6;

            string[] Digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int dMax = 2;

            string[] SpecialCharacters = { "!", "@", "#", "$" };
            int scMax = 2;

            Random r = new Random();
            int category = 0;

            while (ucMax + lcMax + dMax + scMax > 2 || ucMax == 2 || dMax == 2 || scMax == 2)
            {
                category = r.Next(1, 5); //[1...4]

                if (category == 1)
                {
                    if (ucMax == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ret += UpperCaseLetters[r.Next(0, 26)];
                        ucMax = ucMax - 1;
                    }
                }
                else if (category == 2)
                {
                    if (lcMax == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ret += LowerCaseLetters[r.Next(0, 26)];
                        lcMax = lcMax - 1;
                    }
                }
                else if (category == 3)
                {
                    if (dMax == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ret += Digits[r.Next(0, 10)];
                        dMax = dMax - 1;
                    }
                }
                else if (category == 4)
                {
                    if (scMax == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ret += SpecialCharacters[r.Next(0, 4)];
                        scMax = scMax - 1;
                    }
                }

            }

            return ret;
        }
    }
}
