using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class FIHeader
    {
        public int Id { get; set; }
        public int AuditId { get; set; } //?????????
        public string Title { get; set; }
        //public int FICategoryId { get; set; } //?????????
        public FICategory FICategory { get; set; }
        //public int InsUserId { get; set; }
        //public Users InsUser { get; set; }
        //public DateTime InsDt { get; set; }
        //public int UpdUserId { get; set; }
        //public Users UpdUser { get; set; }
        //public DateTime UpdDt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; } //?????????

        public List<FIDetail> FIDetails { get; set; }

        public FIHeader()
        {
        }

        /*
        public static bool isEqual(FIHeader x, FIHeader y)
        {
            if (x.Id == y.Id && x.AuditId == y.AuditId && x.Title == y.Title && x.FICategoryId == y.FICategoryId && FICategory.isEqual(x.FICategory, y.FICategory))
                return true;
            else
                return false;
        }
        */

        public static bool Insert(FIHeader fiHeader) //INSERT [dbo].[FIHeader]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIHeader] ([AuditId], [Title], [FICategoryId], [InsUserId], [InsDt]) VALUES " +
                           "(@AuditId, encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title)), " +
                           "@FICategoryId, @InsUserId, getDate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@AuditId", fiHeader.AuditId);
                cmd.Parameters.AddWithValue("@Title", fiHeader.Title);
                cmd.Parameters.AddWithValue("@FICategoryId", fiHeader.FICategory.Id);
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

        public static bool Update(FIHeader header)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIHeader] SET [Title] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title)), [FICategoryId] = @FICategoryId, [UpdUserId] = @UpdUserId, " +
                "[UpdDt] = getDate() " +
                "WHERE id=@id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@id", header.Id);
                cmd.Parameters.AddWithValue("@FICategoryId", header.FICategory.Id);
                cmd.Parameters.AddWithValue("@Title", header.Title);
                cmd.Parameters.AddWithValue("@UpdUserId", UserInfo.userDetails.Id);

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

        public static bool Delete(int id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIHeader] SET [IsDeleted] = 1, " +
                "[UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [DelUserID] = @UpdUserID, [DelDt] = getDate() " +
                "WHERE id = @id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@UpdUserID", UserInfo.userDetails.Id);

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
