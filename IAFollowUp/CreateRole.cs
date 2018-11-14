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
    public partial class CreateRole : Form
    {
        public CreateRole()
        {
            InitializeComponent();

            isInsert = true;
        }


        public CreateRole(Role role) //update
        {
            InitializeComponent();

            oldRoleRecord = role;

            isInsert = false;

            txtName.Text = role.Name;
            chbIsAuditor.Checked = role.IsAuditor;
            chbIsAuditee.Checked = role.IsAuditee;
            chbIsAdmin.Checked = role.IsAdmin;
        }

        public bool isInsert = false;
        public bool success = false;
        public Role oldRoleRecord = new Role();
        public Role newRoleRecord = new Role();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Name!");
                return;
            }
            if (chbIsAuditor.Checked == false && chbIsAuditee.Checked == false && chbIsAdmin.Checked == false)
            {
                MessageBox.Show("Please check at least one Role!");
                return;
            }

            newRoleRecord = new Role();

            newRoleRecord.Name = txtName.Text;
            newRoleRecord.IsAdmin = chbIsAdmin.Checked;

            newRoleRecord.IsAuditee = chbIsAuditee.Checked;
            newRoleRecord.IsAuditor = chbIsAuditor.Checked;

            if (chbIsAuditee.Checked || chbIsAuditor.Checked)
            {
                newRoleRecord.PasswordPeriod = 90;
            }

            if (chbIsAdmin.Checked)
            {
                newRoleRecord.PasswordPeriod = 30;
            }

            newRoleRecord.Id = oldRoleRecord.Id; //update only

            if (isInsert) //insert
            {
                if (InsertRole(newRoleRecord))
                {
                    MessageBox.Show("New Role inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New Role has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (UpdateTable_Role(newRoleRecord))
                {
                    MessageBox.Show("Role updated successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The Role has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private bool InsertRole(Role role)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Roles] ([Name],[IsAuditor],[IsAuditee] ,[IsAdmin], [PasswordPeriod], [InsDt]) VALUES " +
                           "(@Name, @IsAuditor, @IsAuditee, @IsAdmin, @PassPeriod, getdate() ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Name", role.Name);
                cmd.Parameters.AddWithValue("@IsAuditor", role.IsAuditor);
                cmd.Parameters.AddWithValue("@IsAuditee", role.IsAuditee);
                cmd.Parameters.AddWithValue("@IsAdmin", role.IsAdmin);
                cmd.Parameters.AddWithValue("@PassPeriod", role.PasswordPeriod);

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

        private bool UpdateTable_Role(Role role)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Roles] SET [Name] = @Name, [IsAuditor] = @IsAuditor, [IsAuditee] = @IsAuditee, " +
                "[IsAdmin] = @IsAdmin, [PasswordPeriod] = @PasswordPeriod " +
                "WHERE id = @id ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@id", role.Id);
                cmd.Parameters.AddWithValue("@Name", role.Name);
                cmd.Parameters.AddWithValue("@IsAuditor", role.IsAuditor);
                cmd.Parameters.AddWithValue("@IsAuditee", role.IsAuditee);
                cmd.Parameters.AddWithValue("@IsAdmin", role.IsAdmin);
                cmd.Parameters.AddWithValue("@PasswordPeriod", role.PasswordPeriod);

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
    }
}
