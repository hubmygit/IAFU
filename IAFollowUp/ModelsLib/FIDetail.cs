using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class FIDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FIHeaderId { get; set; }
        public DateTime ActionDt { get; set; }
        public string ActionReq { get; set; }
        public string ActionCode { get; set; }
        public List<Users> Owners { get; set; }
        public int OwnersCnt { get; set; }
        public int InsUserId { get; set; }
        public Users InsUser { get; set; }
        public DateTime InsDt { get; set; }
        public int UpdUserId { get; set; }
        public Users UpdUser { get; set; }
        public DateTime UpdDt { get; set; }
        public int AttCnt { get; set; }
        public bool IsDeleted { get; set; }

        public FIDetail()
        {
            Owners = new List<Users>();
        }
        
        /*
        public static bool isEqual(FIDetail x, FIDetail y)
        {
            if (x.Id == y.Id && x.FIHeaderId == y.FIHeaderId && x.Description == y.Description && x.ActionReq == y.ActionReq && x.ActionDt == y.ActionDt && x.RevNo == y.RevNo &&
                x.ActionCode == y.ActionCode && Users.isListEqual(x.Owners, y.Owners))
                return true;
            else
                return false;
        }
        */

        public List<Users> getOwners(int detail_Id)
        {
            List<Users> ret = new List<Users>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [OwnerId] " +
                              "FROM [dbo].[FIDetail_Owners] " +
                              "WHERE FIDetailId = @detail_Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detail_Id", detail_Id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Users(Convert.ToInt32(reader["OwnerId"].ToString())));
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
