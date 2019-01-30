using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
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
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
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
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        /*
        public static bool isEqual(Users x, Users y)
        {
            if (x.Id == y.Id && x.FullName == y.FullName)
                return true;
            else
                return false;
        }

        public static bool isListEqual(List<Users> x, List<Users> y)
        {
            if (x.Count == y.Count)// && x.Id == y.Id && x.FullName == y.FullName)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (isEqual(x[i], y[i]) == false)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        */

        public static List<Users> GetSqlUsersList()
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [FullName])) as FullName " +
                              "FROM [dbo].[Users] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users() { Id = Convert.ToInt32(reader["Id"].ToString()), FullName = reader["FullName"].ToString() });
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

        public static List<Users> GetUsersByRole(UserRole role)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
                              "FROM [dbo].[Roles] R, [dbo].[Users] U " +
                              "WHERE R.Id = U.RolesId ";

            if (role != UserRole.None)
            {
                SelectSt += " AND R." + role.ToString() + " = 1 ";
            }

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        RoleName = reader["RoleName"].ToString()
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

        public static List<ComboboxItem> GetUsersComboboxItemsList(List<Users> Users)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Users c in Users)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.FullName });
            }

            return ret;
        }

        public string getEmail()
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [Email])) as Email " +
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
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<Users> getAuditors()
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.[Id], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , U.[FullName])) as FullName, R.Name as RoleName " +
                              "FROM [dbo].[Roles] R, [dbo].[Users] U " +
                              "WHERE R.Id = U.RolesId AND R.Id = 3 ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        RoleName = reader["RoleName"].ToString()
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
