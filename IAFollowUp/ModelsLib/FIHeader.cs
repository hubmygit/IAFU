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
        //public bool IsPublished { get; set; } //?????????

        public List<FIDetail> FIDetails { get; set; }

        public string FIId { get; set; }

        //public bool NeedsAttachment { get; set; }

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
            string InsSt = "INSERT INTO [dbo].[FIHeader] ([AuditId], [Title], [FICategoryId], [FIId], [InsUserId], [InsDt]) VALUES " +
                           "(@AuditId, encryptByPassPhrase(@passPhrase, convert(varchar(7800), @Title)), " +
                           "@FICategoryId, @FIId, @InsUserId, getDate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@AuditId", fiHeader.AuditId);
                cmd.Parameters.AddWithValue("@Title", fiHeader.Title);
                cmd.Parameters.AddWithValue("@FICategoryId", fiHeader.FICategory.Id);
                cmd.Parameters.AddWithValue("@FIId", fiHeader.FIId);
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
            string InsSt = "UPDATE [dbo].[FIHeader] SET [Title] = encryptByPassPhrase(@passPhrase, convert(varchar(7800), @Title)), [FICategoryId] = @FICategoryId, " +
                "[FIId] = @FIId, [UpdUserId] = @UpdUserId, [UpdDt] = getDate() " +
                "WHERE id=@id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@id", header.Id);
                cmd.Parameters.AddWithValue("@FICategoryId", header.FICategory.Id);
                cmd.Parameters.AddWithValue("@Title", header.Title);
                cmd.Parameters.AddWithValue("@FIId", header.FIId);
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

        public static List<FIHeader> Select(bool showDeleted, List<FIDetail> detailList)
        {
            List<FIHeader> ret = new List<FIHeader>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT H.[Id], H.[AuditId], CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , H.[Title])) as Title, " +
                              "H.[FICategoryId], H.[FIId], isnull(H.[IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[FIHeader] H ";

            if (!showDeleted)
            {
                SelectSt += "WHERE isnull(H.[IsDeleted], 'FALSE') = 'FALSE' ";
            }

            SelectSt += "ORDER BY H.Id "; //ToDo

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FIHeader tmp = new FIHeader();
                    FICategory fiCat;

                    if (reader["FICategoryId"] == System.DBNull.Value)
                    {
                        fiCat = new FICategory();
                    }
                    else
                    {
                        fiCat = new FICategory(Convert.ToInt32(reader["FICategoryId"].ToString()));
                    }

                    tmp = new FIHeader()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        AuditId = Convert.ToInt32(reader["AuditId"].ToString()),
                        Title = reader["Title"].ToString(),

                        FICategory = fiCat,
                        FIId = reader["FIId"].ToString(),
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString()),

                        FIDetails = new List<FIDetail>()
                    };

                    if (detailList.Exists(i => i.FIHeaderId == tmp.Id))
                    {
                        tmp.FIDetails = detailList.Where(i => i.FIHeaderId == tmp.Id).ToList();

                        ret.Add(tmp);
                    }

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

        public static FIHeader getFIHeaderbyDetailId(int headerId, bool showDeleted, AuditOwners auditOwners, int detailId)
        {
            FIHeader ret = new FIHeader();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT H.[Id], H.[AuditId], CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , H.[Title])) as Title, " +
                              "H.[FICategoryId], H.[FIId], isnull(H.[IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[FIHeader] H " +
                              "WHERE H.[Id] = @HeaderId ";

            if (!showDeleted)
            {
                SelectSt += "AND isnull(H.[IsDeleted], 'FALSE') = 'FALSE' ";
            }

            SelectSt += "ORDER BY H.Id "; //ToDo

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@HeaderId", headerId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FIHeader tmp = new FIHeader();
                    FICategory fiCat;

                    if (reader["FICategoryId"] == System.DBNull.Value)
                    {
                        fiCat = new FICategory();
                    }
                    else
                    {
                        fiCat = new FICategory(Convert.ToInt32(reader["FICategoryId"].ToString()));
                    }

                    tmp = new FIHeader()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        AuditId = Convert.ToInt32(reader["AuditId"].ToString()),
                        Title = reader["Title"].ToString(),

                        FICategory = fiCat,
                        FIId = reader["FIId"].ToString(),
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString()),

                        //FIDetails = Audit.getFIDetails(Convert.ToInt32(reader["Id"].ToString()), showDeleted, auditOwners)
                        FIDetails = new List<FIDetail>() { new FIDetail(detailId) }
                    };

                    //==============================================================
                    if (UserInfo.roleDetails.IsAdmin)
                    {
                        ret = tmp;
                    }
                    //owner ή έστω και ένα detail published (από αυτά που επιτρέπεται να δει!)
                    //αν ενα header δεν έχει details, οι υπόλοιποι auditors δεν θα δουν τίποτα...
                    else if (auditOwners.IsUser_AuditOwner() || tmp.FIDetails.Exists(i => i.IsPublished == true))
                    {
                        ret = tmp;
                    }
                    //==============================================================

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
