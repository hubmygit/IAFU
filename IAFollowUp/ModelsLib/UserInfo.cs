using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace IAFollowUp
{
    public static class UserInfo
    {
        static UserInfo()
        {
            userDetails = new User();
            roleDetails = new Role();

            WindowsUser = "unknown";
            PcName = "";
            EmailAddress = "";
            userDetails.FullName = "";
            IsAuthorized = false;

            LastThreePasswords = new List<PasswordHistory>();

            //DB_AppUser_Id = 0;


            try
            {
                WindowsUser = Environment.UserName; //get windows/domain logged in username
                PcName = System.Net.Dns.GetHostEntry("").HostName;

                //System.DirectoryServices.AccountManagement.UserPrincipal.Current.IsAccountLockedOut();

                //EmailAddress = UserPrincipal.Current.EmailAddress;
                if (EmailAddress == null) //if domain infos not found
                {
                    EmailAddress = "";
                }

                //userDetails.FullName = UserPrincipal.Current.DisplayName;
                if (userDetails.FullName == null) //if domain infos not found
                {
                    userDetails.FullName = "";
                }

                //DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        //public static string FullName { get; set; }
        public static string EmailAddress { get; set; } //only for init
        public static string WindowsUser { get; set; } //only for init
        public static string PcName { get; set; } //only for init
        public static bool IsAuthorized { get; set; }
        public static User userDetails { get; set; }
        public static Role roleDetails { get; set; }

        public static List<PasswordHistory> LastThreePasswords { get; set; }

        public static DateTime passUpdDate { get; set; }

        public static User get_userDetails(string GivenUserName)
        {
            User ret = new User();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            //string SelectSt = "SELECT [Id], [UserName], [RolesId], [FullName], [Email] FROM [dbo].[Users] WHERE UserName = '" + GivenUserName + "'";

            string SelectSt = "SELECT [Id], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [UserName])) as UserName, " +
                              "[RolesId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase ,  [FullName])) as FullName, " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase ,  [Email])) as Email " +
                              "FROM [dbo].[Users] WHERE " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase ,  [UserName])) = '" + GivenUserName + "'";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.UserName = reader["UserName"].ToString();
                    ret.RolesId = Convert.ToInt32(reader["RolesId"].ToString());
                    ret.FullName = reader["FullName"].ToString();
                    ret.Email = reader["Email"].ToString();
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

        public static Role get_roleDetails(int RolesId)
        {
            Role ret = new Role();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [IsAuditor], [IsAuditee], [IsAdmin], [PasswordPeriod] FROM [dbo].[Roles] WHERE Id = " + RolesId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.Name = reader["Name"].ToString();
                    ret.IsAuditor = Convert.ToBoolean(reader["IsAuditor"].ToString());
                    ret.IsAuditee = Convert.ToBoolean(reader["IsAuditee"].ToString());
                    ret.IsAdmin = Convert.ToBoolean(reader["IsAdmin"].ToString());
                    ret.PasswordPeriod = Convert.ToInt32(reader["PasswordPeriod"].ToString());
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

        public static bool checkPassword(string GivenUserName, string GivenPassword)
        {
            bool ret = false;

            //bool found = false;
            //string pass = "";

            bool Equals = false;

            //string hashGivenPass = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT P.PassUpdDate, " +
                              //P.Password, P.PassUpdDate, " +
                              //"HASHBYTES('SHA2_512', @GivenPassword + @passPhrase) as HashGivenPass, " +
                              "case when HASHBYTES('SHA2_512',  @GivenPassword + @passPhrase) = P.Password then 'True' else 'False' end as Equality " +
                              "FROM [dbo].[PasswordHistory] P left outer join " +
                              "[dbo].[Users] U on P.UsersId = U.Id " +
                              "WHERE P.IsCurrent = 'true' and " +
                              //"U.UserName = '" + GivenUserName + "'";
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase,  U.UserName)) = '" + GivenUserName + "'";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.Add("@GivenPassword", SqlDbType.VarChar);
                cmd.Parameters["@GivenPassword"].Value = GivenPassword;

                cmd.Parameters.Add("@passPhrase", SqlDbType.VarChar);
                cmd.Parameters["@passPhrase"].Value = SqlDBInfo.passPhrase;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //pass = reader["Password"].ToString();
                    passUpdDate = Convert.ToDateTime(reader["PassUpdDate"].ToString());
                    //hashGivenPass = reader["HashGivenPass"].ToString();
                    //found = true;

                    Equals = Convert.ToBoolean(reader["Equality"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            //if (pass.Trim() != "" && pass == hashGivenPass)
            if (Equals)
            {
                ret = true;
            }

            //if (pass.Trim() != "")
            //{
            //}
            //if (found == false)
            //{
            //    //UPDATE [dbo].[PasswordHistory] SET IsCurrent = 'true' WHERE  usersId = 3
            //    //SELECT top (1) Id, Password, PassUpdDate FROM [dbo].[PasswordHistory] where usersId = 3 order by passupddate desc
            //}

            //if (pass == GivenPassword)
            //{
            //    ret = true;
            //}

            return ret;
        }

        public static int getUserId(string GivenUserName)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT U.Id " +
                              "FROM [dbo].[Users] U " +
                              "WHERE CONVERT(varchar(500), DECRYPTBYPASSPHRASE(@passPhrase,  U.UserName)) = '" + GivenUserName + "'";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.Add("@passPhrase", SqlDbType.VarChar);
                cmd.Parameters["@passPhrase"].Value = SqlDBInfo.passPhrase;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
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

        public static DateTime getSqlDatetimeNow()
        {
            DateTime ret = DateTime.Now;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT getdate() as sqldt ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToDateTime(reader["sqldt"].ToString());
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

        public static bool IsPasswordExpired() //(DateTime PassUpdDate, int PasswordPeriod)
        {
            bool ret = false;

            DateTime expirationDate = passUpdDate.AddDays(roleDetails.PasswordPeriod);

            //if (expirationDate < DateTime.Now) 
            if(expirationDate < getSqlDatetimeNow()) //PcTime -> server (SQL) time
            {
                ret = true;
            }

            return ret;
        }

        public static List<PasswordHistory> get_passwordHistoryLastThreeDetails(int userId)
        {
            List<PasswordHistory> ret = new List<PasswordHistory>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT TOP (3) [Id], [UsersId], [Password], [PassUpdDate], [IsCurrent] FROM [dbo].[PasswordHistory] WHERE UsersId = " + userId.ToString() + " ORDER BY PassUpdDate DESC";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new PasswordHistory()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        UsersId = Convert.ToInt32(reader["UsersId"].ToString()),
                        //Password = reader["Password"].ToString(),
                        Pass = (byte[])reader["Password"],
                        PassUpdDate = Convert.ToDateTime(reader["PassUpdDate"].ToString()),
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

        public static void Insert_AppLogIn()
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[AppLogIn] (AppUserId, WinUser, PcName, InsDate) VALUES " + 
                           "(@appUserId, encryptByPassPhrase(@passPhrase, convert(varchar(500), @winUser)), " + 
                           "encryptByPassPhrase(@passPhrase, convert(varchar(500), @pcName)), getdate()) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@appUserId", userDetails.Id);
                cmd.Parameters.AddWithValue("@winUser", UserInfo.WindowsUser);
                cmd.Parameters.AddWithValue("@pcName", UserInfo.PcName);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }

    }
}
