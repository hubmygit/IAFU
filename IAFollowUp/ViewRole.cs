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
    public partial class ViewRole : Form
    {
        public ViewRole()
        {
            InitializeComponent();
            roleList = SelectRole();
        }

        public List<Role> roleList = new List<Role>();

        public static List<Role> SelectRole()
        {
            List<Role> ret = new List<Role>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsAuditor], [IsAuditee], [IsAdmin], [PasswordPeriod], [InsDt] " +
                              "FROM [dbo].[Roles] " +
                              "ORDER BY Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Role()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        IsAuditor = Convert.ToBoolean(reader["IsAuditor"].ToString()),
                        IsAuditee = Convert.ToBoolean(reader["IsAuditee"].ToString()),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"].ToString()),
                        PasswordPeriod = Convert.ToInt32(reader["PasswordPeriod"].ToString()),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString())
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

        public static void FillDataGridView(DataGridView dgv, List<Role> RoleList)
        {
            dgv.Rows.Clear();

            foreach (Role thisRecord in RoleList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Name, dgvColumnHeader = "RoleName" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsAuditor, dgvColumnHeader = "IsAuditor" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsAuditee, dgvColumnHeader = "IsAuditee" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsAdmin, dgvColumnHeader = "IsAdmin" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.PasswordPeriod, dgvColumnHeader = "PassExp" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.InsDt.ToString("dd.MM.yyyy HH:mm:ss"), dgvColumnHeader = "InsDate" });

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
        }

        private void dgvRoleView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvRoleView.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }

                dgvRoleView.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void MIupdate_Click(object sender, EventArgs e)
        {
            if (dgvRoleView.SelectedRows.Count > 0)
            {
                int thisId = Convert.ToInt32(dgvRoleView.SelectedRows[0].Cells["Id"].Value.ToString());
                Role thisRole = roleList.Where(i => i.Id == thisId).First();

                CreateRole frmCreateRole = new CreateRole(thisRole);
                frmCreateRole.Text = "Edit Role";
                frmCreateRole.ShowDialog();

                if (frmCreateRole.success)
                {
                    roleList[roleList.FindIndex(w => w.Id == thisId)] = frmCreateRole.newRoleRecord;

                    FillDataGridView(dgvRoleView, roleList);
                }
            }
        }

        private void ViewRole_Load(object sender, EventArgs e)
        {
            FillDataGridView(dgvRoleView, roleList);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateRole frmNewRole = new CreateRole();
            frmNewRole.ShowDialog();

            if (frmNewRole.success)
            {
                roleList = SelectRole();
                FillDataGridView(dgvRoleView, roleList);
            }
        }

    }
}
