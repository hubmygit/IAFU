using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public class AlertEmails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }


        public AlertEmails()
        {
        }
        public AlertEmails(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [EmailSubject], [EmailBody] " +
                              "FROM [dbo].[Alert_Emails] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                    EmailSubject = reader["EmailSubject"].ToString();
                    EmailBody = reader["EmailBody"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("AlertEmails - The following error occurred: " + ex.Message, true);
            }
        }
    }
}
