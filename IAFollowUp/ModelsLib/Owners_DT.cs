using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Owners_DT
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public DateTime InsDt { get; set; }
        public bool IsActive { get; set; }

        public Owners_DT()
        {
        }

        public static List<Owners_DT> GetOwnerDTList(int givenDetailId, int givenPlaceholderId)
        {
            List<Owners_DT> ret = new List<Owners_DT>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DetailId], [PlaceholderId], [UserId], [InsDt], [IsActive] " +
                              "FROM [dbo].[Owners_DT] " +
                              "WHERE IsActive = 'TRUE' and and DetailId = @detId and PlaceholderId = @phId ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", givenDetailId);
                cmd.Parameters.AddWithValue("@phId", givenPlaceholderId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Owners_DT()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString()),
                        IsActive = Convert.ToBoolean(reader["IsActive"].ToString())
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

        public static List<Users> GetOwnerDTUsersList(int givenDetailId, int givenPlaceholderId)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [UserId] " +
                              "FROM [dbo].[Owners_DT] " +
                              "WHERE IsActive = 'TRUE' and DetailId = @detId and PlaceholderId = @phId "; 
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", givenDetailId);
                cmd.Parameters.AddWithValue("@phId", givenPlaceholderId);

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