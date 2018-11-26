using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAuditor { get; set; }
        public bool IsAuditee { get; set; }
        public bool IsAdmin { get; set; }
        public int PasswordPeriod { get; set; }
        public DateTime InsDt { get; set; }

        public Role()
        { }

        public Role(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsAuditor], [IsAuditee], [IsAdmin], [PasswordPeriod], [InsDt] " +
                              "FROM [dbo].[Roles] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Name = reader["Name"].ToString();
                    IsAuditor = Convert.ToBoolean(reader["IsAuditor"].ToString());
                    IsAuditee = Convert.ToBoolean(reader["IsAuditee"].ToString());
                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"].ToString());
                    PasswordPeriod = Convert.ToInt32(reader["PasswordPeriod"].ToString());
                    InsDt = Convert.ToDateTime(reader["InsDt"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

        }

        /*
        public static bool isEqual(Role x, Role y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.IsAuditor == y.IsAuditor && x.IsAuditee == y.IsAuditee && x.IsAdmin == y.IsAdmin && x.PasswordPeriod == y.PasswordPeriod)
                return true;
            else
                return false;
        }
        */

        public static List<ComboboxItem> GetRolesComboboxItemsList(List<Role> Roles)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Role c in Roles)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }
    }
}
