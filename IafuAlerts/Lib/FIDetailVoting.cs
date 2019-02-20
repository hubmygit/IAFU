using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace IafuAlerts
{
    public class FIDetailVoting
    {
        //public int Id { get; set; }
        //public int DetailId { get; set; }
        //public Users User { get; set; }
        //public AuditorsRoles AuditorRole { get; set; }
        //public Classification Classification { get; set; }
        //public bool IsCurrent { get; set; }
        //public DateTime InsDate { get; set; }

        public static bool HasAlreadyVoted(int detailId, int userId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[FIDetail_Voting] " +
                              "WHERE DetailId = @detId AND UserId = @userId AND IsCurrent = 'True' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = true;
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("FIDetailVoting.HasAlreadyVoted - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }

        public static DateTime? VotingDate_ifHasAlreadyVoted(int detailId, int userId)
        {
            DateTime? ret = null;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT InsDate FROM [dbo].[FIDetail_Voting] " +
                              "WHERE DetailId = @detId AND UserId = @userId AND IsCurrent = 'True' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToDateTime(reader["InsDate"].ToString()); ;
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("FIDetailVoting.VotingDate_ifHasAlreadyVoted - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }
    }
}
