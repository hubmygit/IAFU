using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class AppLogIn
    {
        public int Id { get; set; }
        public string WinUser { get; set; }
        public string PcName { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public Users AppUser { get; set; }

        public AppLogIn()
        {

        }

        public static BindingList<AppLogIn> AppLogInList(int fromYear, int fromMonth, int fromDay, 
                                                         int toYear, int toMonth, int toDay)
        {
            BindingList<AppLogIn> ret = new BindingList<AppLogIn>();

            DateTime dtFrom = new DateTime(fromYear, fromMonth, fromDay);
            DateTime dtTo = new DateTime(toYear, toMonth, toDay);

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, AppUserId, CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , WinUser)) as WinUser, " +
                              "CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , PcName)) as PcName, InsDate, ExitDate " +
                              "FROM [dbo].[AppLogIn] " +
                              "WHERE InsDate >= @FromDt AND InsDate < DATEADD(day, 1, @ToDt)";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@FromDt", dtFrom);
                cmd.Parameters.AddWithValue("@ToDt", dtTo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppLogIn appLogin = new AppLogIn();
                    appLogin.Id = Convert.ToInt32(reader["Id"].ToString());
                    appLogin.WinUser = reader["WinUser"].ToString();
                    appLogin.PcName = reader["PcName"].ToString();
                    appLogin.InsDate = Convert.ToDateTime(reader["InsDate"].ToString());
                    if (reader["ExitDate"] == DBNull.Value)
                    {
                        appLogin.ExitDate = null;
                    }
                    else
                    {
                        appLogin.ExitDate = Convert.ToDateTime(reader["ExitDate"].ToString());
                    }
                    appLogin.AppUser = new Users(Convert.ToInt32(reader["AppUserId"].ToString()));

                    ret.Add(appLogin);
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

        public static BindingList<AppLogIn> AppLogInList(int fromYear, int fromMonth,
                                                         int toYear, int toMonth)
        {
            BindingList<AppLogIn> ret = new BindingList<AppLogIn>();

            DateTime dtFrom = new DateTime(fromYear, fromMonth, 1);
            DateTime dtTo = new DateTime(toYear, toMonth, 1);

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, AppUserId, CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , WinUser)) as WinUser, " +
                              "CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , PcName)) as PcName, InsDate, ExitDate " +
                              "FROM [dbo].[AppLogIn] " +
                              "WHERE InsDate >= @FromDt AND InsDate < DATEADD(month, 1, @ToDt)";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@FromDt", dtFrom);
                cmd.Parameters.AddWithValue("@ToDt", dtTo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppLogIn appLogin = new AppLogIn();
                    appLogin.Id = Convert.ToInt32(reader["Id"].ToString());
                    appLogin.WinUser = reader["WinUser"].ToString();
                    appLogin.PcName = reader["PcName"].ToString();
                    appLogin.InsDate = Convert.ToDateTime(reader["InsDate"].ToString());
                    if (reader["ExitDate"] == DBNull.Value)
                    {
                        appLogin.ExitDate = null;
                    }
                    else
                    {
                        appLogin.ExitDate = Convert.ToDateTime(reader["ExitDate"].ToString());
                    }
                    appLogin.AppUser = new Users(Convert.ToInt32(reader["AppUserId"].ToString()));

                    ret.Add(appLogin);
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

        public static BindingList<AppLogIn> AppLogInList(int fromYear,
                                                         int toYear)
        {
            BindingList<AppLogIn> ret = new BindingList<AppLogIn>();

            DateTime dtFrom = new DateTime(fromYear, 1, 1);
            DateTime dtTo = new DateTime(toYear, 1, 1);

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, AppUserId, CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , WinUser)) as WinUser, " +
                              "CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , PcName)) as PcName, InsDate, ExitDate " +
                              "FROM [dbo].[AppLogIn] " +
                              "WHERE InsDate >= @FromDt AND InsDate < DATEADD(year, 1, @ToDt)";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@FromDt", dtFrom);
                cmd.Parameters.AddWithValue("@ToDt", dtTo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppLogIn appLogin = new AppLogIn();
                    appLogin.Id = Convert.ToInt32(reader["Id"].ToString());
                    appLogin.WinUser = reader["WinUser"].ToString();
                    appLogin.PcName = reader["PcName"].ToString();
                    appLogin.InsDate = Convert.ToDateTime(reader["InsDate"].ToString());
                    if (reader["ExitDate"] == DBNull.Value)
                    {
                        appLogin.ExitDate = null;
                    }
                    else
                    {
                        appLogin.ExitDate = Convert.ToDateTime(reader["ExitDate"].ToString());
                    }
                    appLogin.AppUser = new Users(Convert.ToInt32(reader["AppUserId"].ToString()));

                    ret.Add(appLogin);
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

        public static BindingList<AppLogIn> AppLogInList()
        {
            BindingList<AppLogIn> ret = new BindingList<AppLogIn>();
                        
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, AppUserId, CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , WinUser)) as WinUser, " +
                              "CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , PcName)) as PcName, InsDate, ExitDate " +
                              "FROM [dbo].[AppLogIn] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppLogIn appLogin = new AppLogIn();
                    appLogin.Id = Convert.ToInt32(reader["Id"].ToString());
                    appLogin.WinUser = reader["WinUser"].ToString();
                    appLogin.PcName = reader["PcName"].ToString();
                    appLogin.InsDate = Convert.ToDateTime(reader["InsDate"].ToString());
                    if (reader["ExitDate"] == DBNull.Value)
                    {
                        appLogin.ExitDate = null;
                    }
                    else
                    {
                        appLogin.ExitDate = Convert.ToDateTime(reader["ExitDate"].ToString());
                    }
                    appLogin.AppUser = new Users(Convert.ToInt32(reader["AppUserId"].ToString()));

                    ret.Add(appLogin);
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
