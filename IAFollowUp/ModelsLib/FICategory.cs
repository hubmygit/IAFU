using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class FICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool NeedsApproval { get; set; }

        public FICategory()
        {

        }

        public FICategory(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NeedsApproval] " +
                              "FROM [dbo].[FICategory] " +
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
                    NeedsApproval = Convert.ToBoolean(reader["NeedsApproval"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }



        }

        public static List<ComboboxItem> GetFICategoryComboboxItemsList(List<FICategory> FICategories)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (FICategory c in FICategories)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }

        public static List<FICategory> GetSqlFICategoriesList()
        {
            List<FICategory> ret = new List<FICategory>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [NeedsApproval] " +
                              "FROM [dbo].[FICategory] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new FICategory() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), NeedsApproval = Convert.ToBoolean(reader["NeedsApproval"].ToString()) });
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

        /*
        public static bool isEqual(FICategory x, FICategory y)
        {
            if (x.Id == y.Id && x.Name == y.Name && x.NeedsApproval == y.NeedsApproval)
                return true;
            else
                return false;
        }
        */
    }
}
