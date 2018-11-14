using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IAFollowUp
{
    public static class AppVer
    {

        public static bool IsLatestVersion() //Compare app version with db version (2 digits only)
        {
            bool ret = true;
            string CurrentVersion = getCurrentAppVersion();
            string LatestVersion = getLatestAppVersionFromDB();

            string[] CurVer2Dig = CurrentVersion.Split('.');
            string[] LatVer2Dig = LatestVersion.Split('.');

            //if (CurrentVersion < LatestVersion)
            if ((CurVer2Dig[0] + "." + CurVer2Dig[1]) != (LatVer2Dig[0] + "." + LatVer2Dig[1]))
            {
                ret = false;
                MessageBox.Show("Your application version is older than the current version! \r\nIt is necessary to upgrade to continue.");
            }
            else if (CurrentVersion != LatestVersion)
            {
                MessageBox.Show("Your application version is older than the current version! \r\nPlease upgrade as soon as possible.");
            }

            return ret;
        }

        //public static int getCurrentAppVersion()
        public static string getCurrentAppVersion()
        {
            //this is 'File Version' - for 'Assembly Version' use System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() 
            //int ret = 0;
            //string appVer = Application.ProductVersion.Replace(".", "");
            //bool succeeded = Int32.TryParse(appVer, out ret);

            string ret = Application.ProductVersion;

            return ret;
        }

        //public static int getLatestAppVersionFromDB()
        public static string getLatestAppVersionFromDB()
        {
            //int ret = 0;
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT AppVersion FROM [dbo].[AppVersion] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //ret = Convert.ToInt32(reader["Num"].ToString());
                    ret = reader["AppVersion"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
    }
}
