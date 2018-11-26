using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public Companies()
        {
        }
        public Companies(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] " +
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
                    NameShort = reader["NameShort"].ToString();
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
        public static bool isEqual(Companies x, Companies y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.NameShort == y.NameShort)
                return true;
            else
                return false;
        }
        */

        public static List<Companies> GetSqlCompaniesList()
        {
            List<Companies> ret = new List<Companies>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NameShort] " +
                              "FROM [dbo].[Companies] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Companies() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NameShort = reader["NameShort"].ToString() });
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


        public static List<ComboboxItem> GetCompaniesComboboxItemsList(List<Companies> Companies)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Companies c in Companies)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }


    }
}
