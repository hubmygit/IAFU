using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class DetailOwners
    {
        public int Id { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public DateTime InsDt { get; set; }
        public bool IsCurrent { get; set; }

        public DetailOwners()
        {
        }

        public DetailOwners(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString()));
                    User = new Users(Convert.ToInt32(reader["UserId"].ToString()));
                    InsDt = Convert.ToDateTime(reader["InsDt"].ToString());
                    IsCurrent = Convert.ToBoolean(reader["IsCurrent"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static List<DetailOwners> GetSqlDetailOwnersList()
        {
            List<DetailOwners> ret = new List<DetailOwners>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new DetailOwners()
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

        public static List<DetailOwners> GetCurrentDetailOwnersList(int givenPlaceholderId)
        {
            List<DetailOwners> ret = new List<DetailOwners>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new DetailOwners()
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

        public static DetailOwners GetCurrentDetailOwner(int givenPlaceholderId)
        {
            DetailOwners ret = new DetailOwners();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = new DetailOwners()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString()),
                        IsCurrent = Convert.ToBoolean(reader["IsCurrent"].ToString())
                    };
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

        

        public static List<DetailOwners> GetCurrentDetailOwnersListPerCompany(int givenCompanyId)
        {
            List<DetailOwners> ret = new List<DetailOwners>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId in (SELECT id FROM [dbo].[Placeholders] WHERE CompanyId = " + givenCompanyId.ToString() + " ) " ;
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new DetailOwners()
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

    }
}
