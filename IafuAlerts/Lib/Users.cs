using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string RoleName { get; set; }

        public Users()
        {
        }
        public Users(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
                              "FROM [dbo].[Roles] R, [dbo].[Users] U  " +
                              "WHERE R.Id = U.RolesId AND U.Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    FullName = reader["FullName"].ToString();
                    RoleName = reader["RoleName"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("Users - The following error occurred: " + ex.Message, true);
            }
        }

        public string getEmail()
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , [Email])) as Email " +
                              "FROM [dbo].[Users] " +
                              "WHERE Id = @Id ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@Id", this.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["Email"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("Users.getEmail - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }

        public static Users getCAE()
        {
            Users ret = new Users();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
                              "FROM [dbo].[Roles] R, [dbo].[Users] U " +
                              "WHERE R.Id = U.RolesId AND R.Id = 2 AND U.IsAuditorActive = 1 ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = new Users()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        RoleName = reader["RoleName"].ToString()
                    };
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("Users.getCAE - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }

    }
}
