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
    public partial class ViewUser : Form
    {
        public ViewUser()
        {
            InitializeComponent();

            userList = SelectedUser();
        }
        public List<User> userList = new List<User>();

        public static List<User> SelectedUser()
        {
            List<User> ret = new List<User>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase, [UserName])) as UserName, CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase, [FullName])) as FullName," +
                " CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase, [Email])) as Email, [RolesId], [InsDt], " +
                "CASE WHEN (select count(*) from [dbo].[PasswordHistory] WHERE UsersId = [dbo].[Users].[Id] AND IsCurrent = 1) > 0 THEN 'True' ELSE 'False' END as HasActivePassword " +
                              "FROM [dbo].[Users] " +
                              "ORDER BY FullName ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new User()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        UserName = reader["UserName"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        RolesId = Convert.ToInt32(reader["RolesId"].ToString()),
                        Role = new Role(Convert.ToInt32(reader["RolesId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString()),
                        HasActivePassword = Convert.ToBoolean(reader["HasActivePassword"].ToString())
                    });
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
        public static void FillDataGridView(DataGridView dgv, List<User> UserList)
        {
            dgv.Rows.Clear();

            foreach (User thisRecord in UserList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.UserName, dgvColumnHeader = "UserName" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FullName, dgvColumnHeader = "FullName" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Email, dgvColumnHeader = "Email" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Role.Name, dgvColumnHeader = "Role" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.InsDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "InsDate" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.HasActivePassword, dgvColumnHeader = "HasActivePassword" });

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateUser frmNewUser = new CreateUser();
            frmNewUser.ShowDialog();

            if (frmNewUser.success)
            {
                userList = SelectedUser();
                FillDataGridView(dgvUserView, userList);
            }
        }

        private void MIupdate_Click(object sender, EventArgs e)
        {
            if (dgvUserView.SelectedRows.Count > 0)
            {
                int thisId = Convert.ToInt32(dgvUserView.SelectedRows[0].Cells["Id"].Value.ToString());
                User thisUser = userList.Where(i => i.Id == thisId).First();

                CreateUser frmCreateUser = new CreateUser(thisUser);
                frmCreateUser.Text = "Edit User";
                frmCreateUser.ShowDialog();

                if (frmCreateUser.success)
                {
                    userList[userList.FindIndex(w => w.Id == thisId)] = frmCreateUser.newUserRecord;

                    FillDataGridView(dgvUserView, userList);
                }
            }
        }

        private void dgvUserView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvUserView.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }

                dgvUserView.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            FillDataGridView(dgvUserView, userList);
        }

        private void MIinitPass_Click(object sender, EventArgs e)
        {
            if (dgvUserView.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to Initialize Password for this User?", "Password Initialization", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                int thisId = Convert.ToInt32(dgvUserView.SelectedRows[0].Cells["Id"].Value.ToString());
                string initPass = CreateUser.GetRandomPassword();
                byte[] HashPass = ChangePassword.Encrypt(initPass);

                if (ChangePassword.update_PasswordHistory_TableAllRecsPerUser(thisId, false))
                {
                    if (ChangePassword.insertInto_PasswordHistory_Table(thisId, HashPass))
                    {
                        MessageBox.Show("Password Initialized successfully!");

                        NewPassword frmNewPass = new NewPassword(initPass);
                        frmNewPass.ShowDialog();

                        userList = SelectedUser();
                        FillDataGridView(dgvUserView, userList);
                    }
                    else
                    {
                        MessageBox.Show("Error while initializing password!");
                    }
                }
                else
                {
                    MessageBox.Show("Error while initializing password!");
                }


            }
        }

        private void MIdisable_Click(object sender, EventArgs e)
        {
            if (dgvUserView.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to Disable (Block) this User?", "Block User", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                int thisId = Convert.ToInt32(dgvUserView.SelectedRows[0].Cells["Id"].Value.ToString());

                if (ChangePassword.update_PasswordHistory_TableAllRecsPerUser(thisId, false))
                {
                    MessageBox.Show("User disabled (blocked) successfully!");

                    userList = SelectedUser();
                    FillDataGridView(dgvUserView, userList);
                }
                else
                {
                    MessageBox.Show("An error occured while blocking user!");
                }
            }
        }

    }
}
