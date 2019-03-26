using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public class Owners_GM
    {
        public int Id { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public DateTime InsDt { get; set; }
        public bool IsCurrent { get; set; }

        public Owners_GM()
        {
        }
               
        public static List<Users> GetOwnerGMUsersList(int givenPlaceholderId)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [UserId] " +
                              "FROM [dbo].[Owners_GM] " +
                              "WHERE IsCurrent = 'TRUE' and IsNotifRecipient = 'TRUE' and PlaceholderId = " + givenPlaceholderId.ToString();
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
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("Owners_GM.GetOwnerGMUsersList - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }

    }
}
