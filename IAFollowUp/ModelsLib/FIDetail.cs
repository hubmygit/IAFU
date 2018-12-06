using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class FIDetail
    {
        public int Id { get; set; }
        public string Description { get; set; } //*
        public int FIHeaderId { get; set; }
        public DateTime? ActionDt { get; set; } //
        public string ActionReq { get; set; } //
        public string ActionCode { get; set; } //the only mandatory field!!!
        public List<Users> Owners { get; set; } //

        //public int OwnersCnt { get; set; }

        //public int InsUserId { get; set; }
        //public Users InsUser { get; set; }
        //public DateTime InsDt { get; set; }
        //public int UpdUserId { get; set; }
        //public Users UpdUser { get; set; }
        //public DateTime UpdDt { get; set; }

        //public int AttCnt { get; set; }

        public bool IsClosed { get; set; }
        public bool IsFinalized { get; set; }

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

        public static List<Users> getOwners(int detail_Id)
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

        private static bool InsertIntoTable_FIDetailOwners(int fiDetailId, Users SingleOwner) //INSERT [dbo].[FIDetail_Owners]
        {
            bool ret = false;

            //dgvOwners.Rows.Add(new object[] { thisOwner.Id, thisOwner.FullName, thisOwner.RoleName });
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Owners] ([FIDetailId], [OwnerId], [InsUserId], [InsDate]) " +
                           "VALUES (@DetailId, @OwnerId, @InsUserId, getDate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@DetailId", fiDetailId);
                cmd.Parameters.AddWithValue("@OwnerId", SingleOwner.Id);
                cmd.Parameters.AddWithValue("@InsUserId", UserInfo.userDetails.Id);

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

        public static bool Insert(FIDetail fiDetail) //INSERT [dbo].[FIDetail]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail] ([FIHeaderId], [Description], [ActionReq], [ActionDt], [ActionCode], [InsUserId], [InsDt] ) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES " +
                           "(@HeaderId, encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq))," +
                           "@ActionDt, @ActionCode, @InsUserId, getDate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@HeaderId", fiDetail.FIHeaderId);
                cmd.Parameters.AddWithValue("@Description", fiDetail.Description);
                cmd.Parameters.AddWithValue("@ActionReq", fiDetail.ActionReq);
                //cmd.Parameters.AddWithValue("@ActionDt", fiDetail.ActionDt);
                if (fiDetail.ActionDt == null)
                {
                    cmd.Parameters.AddWithValue("@ActionDt", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ActionDt", fiDetail.ActionDt);
                }
                cmd.Parameters.AddWithValue("@ActionCode", fiDetail.ActionCode);
                cmd.Parameters.AddWithValue("@InsUserId", UserInfo.userDetails.Id);

                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fiDetail.Id = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();

                //int rowsAffected = cmd.ExecuteNonQuery();

                //if (rowsAffected > 0)
                if (fiDetail.Id > 0)
                {
                    ret = true;

                    foreach (Users thisOwner in fiDetail.Owners)
                    {
                        if (!InsertIntoTable_FIDetailOwners(fiDetail.Id, thisOwner))
                        {
                            ret = false;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

        public static bool DeleteOwners(int detailId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[FIDetail_Owners] WHERE FIDetailId = @FIDetailId ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@FIDetailId", detailId);

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

        public static bool Update(FIDetail detail)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [FIHeaderId] = @HeaderId, [Description] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), " +
                          "[ActionReq] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq)), [ActionDt] = @ActionDt, [ActionCode] = @ActionCode, " +
                          "[UpdUserId] = @UpdUserId, [UpdDt] = getDate() " +
                          "WHERE id = @id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                cmd.Parameters.AddWithValue("@id", detail.Id);

                cmd.Parameters.AddWithValue("@HeaderId", detail.FIHeaderId);
                //cmd.Parameters.AddWithValue("@ActionDt", detail.ActionDt);
                if (detail.ActionDt == null)
                {
                    cmd.Parameters.AddWithValue("@ActionDt", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ActionDt", detail.ActionDt);
                }
                cmd.Parameters.AddWithValue("@Description", detail.Description);
                cmd.Parameters.AddWithValue("@ActionReq", detail.ActionReq);
                cmd.Parameters.AddWithValue("@ActionCode", detail.ActionCode);
                cmd.Parameters.AddWithValue("@UpdUserId", UserInfo.userDetails.Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;

                    //delete old Owners
                    if (!DeleteOwners(detail.Id))
                    {
                        ret = false;
                    }

                    foreach (Users thisOwner in detail.Owners)
                    {
                        if (!InsertIntoTable_FIDetailOwners(detail.Id, thisOwner))
                        {
                            ret = false;
                        }
                    }
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
