using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Owners_MT
    {
        public int Id { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public DateTime InsDt { get; set; }
        public bool IsCurrent { get; set; }

        public Owners_MT()
        {
        }

        public Owners_MT(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners_MT] " +
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

        public static List<Owners_MT> GetSqlDetailOwnersList()
        {
            List<Owners_MT> ret = new List<Owners_MT>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners_MT] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Owners_MT()
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

        public static List<Owners_MT> GetCurrentDetailOwnersList(int givenPlaceholderId)
        {
            List<Owners_MT> ret = new List<Owners_MT>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners_MT] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Owners_MT()
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

        public static Owners_MT GetCurrentOwnerMT(int givenPlaceholderId)
        {
            Owners_MT ret = new Owners_MT();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners_MT] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = new Owners_MT()
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

        

        public static List<Owners_MT> GetCurrentDetailOwnersListPerCompany(int givenCompanyId)
        {
            List<Owners_MT> ret = new List<Owners_MT>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [PlaceholderId], [UserId], [InsDt], [IsCurrent] " +
                              "FROM [dbo].[Owners_MT] " +
                              "WHERE IsCurrent = 'TRUE' and PlaceholderId in (SELECT id FROM [dbo].[Placeholders] WHERE CompanyId = " + givenCompanyId.ToString() + " ) " ;
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Owners_MT()
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
