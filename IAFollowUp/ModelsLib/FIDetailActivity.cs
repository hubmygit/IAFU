using System;
using System.Collections.Generic;
using System.Data;
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
        public string Activity { get; set; } //todo encrypted?????
        public string CommentRtf { get; set; } //todo encrypted
        public string CommentText { get; set; } //todo encrypted
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
                    FIDetailActivity tmp = new FIDetailActivity();

                    tmp = new FIDetailActivity()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        Activity = reader["Activity"].ToString(),
                        FromUser = new Users(Convert.ToInt32(reader["FromUserId"].ToString())),
                        ToUser = new Users(Convert.ToInt32(reader["ToUserId"].ToString())),
                        InsDt = Convert.ToDateTime(reader["InsDt"].ToString())
                    };



                    //MT - Show All
                    //GM - Show All
                    //Delegatee - Show All
                    //Auditor - Show public


                    //a) Admin - All
                    if (UserInfo.roleDetails.IsAdmin)
                    {
                        ret.Add(tmp);
                    }
                    //b) MT - 
                    //else if (detailOwnersMT.IsUser_DetailOwner())
                    //{
                    //    if (tmp.IsPublished)
                    //    {
                    //        ret.Add(tmp);
                    //    }
                    //}


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

        public static bool Insert(FIDetailActivity fiDetailActivity) //INSERT [dbo].[FIDetail_Activity]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Activity] ([DetailId], [Activity], [CommentText], [CommentRtf], [FromUserId], [ToUserId], [IsPublic], [InsDt]) VALUES " +
                           "(@DetailId, @Activity, @CommentText, @CommentRtf, @FromUserId, @ToUserId, @IsPublic, getDate())"; 
            //encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title)), " +

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@DetailId", fiDetailActivity.DetailId);
                cmd.Parameters.AddWithValue("@Activity", fiDetailActivity.Activity);

                if (fiDetailActivity.CommentText.Trim() == "")
                {
                    cmd.Parameters.AddWithValue("@CommentText", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CommentRtf", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CommentText", fiDetailActivity.CommentText);
                    cmd.Parameters.AddWithValue("@CommentRtf", fiDetailActivity.CommentRtf);
                }

                cmd.Parameters.AddWithValue("@FromUserId", UserInfo.userDetails.Id);
                cmd.Parameters.AddWithValue("@ToUserId", fiDetailActivity.ToUser.Id);
                cmd.Parameters.AddWithValue("@IsPublic", true);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

    }
}
