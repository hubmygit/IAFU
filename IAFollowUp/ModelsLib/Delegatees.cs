using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Delegatees
    {
        public int Id { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public DateTime InsDt { get; set; }
        public bool IsCurrent { get; set; }

        public Delegatees()
        {
        }

        public static List<Delegatees> GetDelegateesList(int givenPlaceholderId)
        {
            List<Delegatees> ret = new List<Delegatees>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Delegatees] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Delegatees()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString()),
                        IsCurrent = Convert.ToBoolean(reader["IsCurrent"].ToString())
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

        public static List<Users> GetDelegateesUsersList(int givenPlaceholderId)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [UserId] " +
                              "FROM [dbo].[Delegatees] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users(Convert.ToInt32(reader["UserId"].ToString())));
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
