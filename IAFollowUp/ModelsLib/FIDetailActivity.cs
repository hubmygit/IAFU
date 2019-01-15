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
        public string CommentRtf { get; set; } //todo encrypted
        public string CommentText { get; set; } //todo encrypted
        public bool IsPublic { get; set; }
        public string AttachmentName { get; set; } //todo to new table
        public byte[] AttachmentCont { get; set; } //todo encrypted to new table
        public string FromUser { get; set; } //todo Id-> int
        public string ToUser { get; set; } //todo Id-> int
        public int InsUserId { get; set; } //???
        public DateTime InsDt { get; set; }

        public FIDetailActivity()
        {
        }

        public static List<FIDetailActivity> getDetailActivity(int detailId)
        {
            List<FIDetailActivity> ret = new List<FIDetailActivity>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id] ............................... " +
                              "FROM [dbo].[FIDetail_Activity] " +
                              "WHERE DetailId = " + detailId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Id = Convert.ToInt32(reader["Id"].ToString());
                    //Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString()));
                    //Department = new Departments(Convert.ToInt32(reader["DepartmentId"].ToString()));
                    ret.Add(new FIDetailActivity()
                    {
                        //Id = Convert.ToInt32(reader["Id"].ToString()),
                        //Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString())),
                        //Department = new Departments(Convert.ToInt32(reader["DepartmentId"].ToString()))
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
