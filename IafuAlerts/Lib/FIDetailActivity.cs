using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public class FIDetailActivity
    {
        //public int Id { get; set; }
        //public int DetailId { get; set; }
        //public DateTime? ActionDt { get; set; }
        //public ActivityDescription ActivityDescription { get; set; }
        //public string CommentRtf { get; set; } //todo encrypted
        //public string CommentText { get; set; } //todo encrypted
        ////public bool IsPublic { get; set; } //???
        ////public string AttachmentName { get; set; } //todo to new table
        ////public byte[] AttachmentCont { get; set; } //todo encrypted to new table
        //public Users FromUser { get; set; }
        //public Users ToUser { get; set; }
        //public DateTime InsDt { get; set; }

        //public Placeholders Placeholders { get; set; }

        //public bool HasAttachments { get; set; }

        public static ActionSide getActionSide_forAuditors(FIDetail detail)
        {
            ActionSide ret = new ActionSide(1); //Auditors

            foreach (Placeholders ph in detail.Placeholders)
            {
                if (getActionSide_forAuditees(detail.Id, ph.Id).Id == 2)
                {
                    ret = new ActionSide(2); //Auditees
                }
            }

            return ret;
        }

        public static DateTime? LastPublishDateFromMTtoIA(int detailId)
        {
            DateTime? ret = null;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) InsDt " +
                              "FROM [dbo].[FIDetail_Activity] " +
                              "WHERE ActivityDescriptionId = 2 AND DetailId = @detailId " +
                              "ORDER BY InsDt DESC";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detailId", detailId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToDateTime(reader["InsDt"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("FIDetailActivity.LastPublishDateFromMTtoIA - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }

        public static ActionSide getActionSide_forAuditees(int detailId, int placeholderId)
        {
            ActionSide ret = new ActionSide();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) D.[ActionSideId] " +
                              "FROM [dbo].[FIDetail_Activity] A left outer join [dbo].[Activity_Descriptions] D on A.ActivityDescriptionId = D.Id " +
                              "WHERE A.DetailId = @detId AND A.PlaceholderId = @phId AND D.ActionSideId <> 3 " +
                              "ORDER BY A.InsDt Desc";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);
                cmd.Parameters.AddWithValue("@phId", placeholderId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = new ActionSide(Convert.ToInt32(reader["ActionSideId"].ToString()));
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("FIDetailActivity.getActionSide_forAuditees - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }

    }
}
