using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class FIDetailActivity
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string Activity { get; set; } //todo encrypted
        //public string CommentRtf { get; set; } //todo encrypted
        //public string CommentText { get; set; } //todo encrypted
        //public bool IsPublic { get; set; } //???
        //public string AttachmentName { get; set; } //todo to new table
        //public byte[] AttachmentCont { get; set; } //todo encrypted to new table
        public Users FromUser { get; set; } 
        public Users ToUser { get; set; } 
        public DateTime InsDt { get; set; }

        public FIDetailActivity()
        {
        }

        public static List<FIDetailActivity> getDetailActivity(int detailId)
        {
            List<FIDetailActivity> ret = new List<FIDetailActivity>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DetailId], [Activity], [FromUserId], [ToUserId], [InsDt] " +
                              "FROM [dbo].[FIDetail_Activity] " +
                              "WHERE DetailId = @detId " +
                              "ORDER BY InsDt Desc";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                    
                    ret.Add(new FIDetailActivity()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        Activity = reader["Activity"].ToString(),
                        FromUser = new Users(Convert.ToInt32(reader["FromUserId"].ToString())),
                        ToUser = new Users(Convert.ToInt32(reader["ToUserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString())
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
