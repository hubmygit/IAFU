using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class AuditRating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuditRating()
        { }

        /*
        public static bool isEqual(AuditRating x, AuditRating y)
        {
            if (x.Id == y.Id && x.Name == y.Name)
                return true;
            else
                return false;
        }
        */

        public static List<ComboboxItem> GetAuditRatingComboboxItemsList(List<AuditRating> rating)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (AuditRating c in rating)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }

        public AuditRating(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [id], [Name] " +
                              "FROM [dbo].[AuditRating] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<AuditRating> GetSqlAuditRatingList()
        {
            List<AuditRating> ret = new List<AuditRating>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] " +
                              "FROM [dbo].[AuditRating] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new AuditRating() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
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
