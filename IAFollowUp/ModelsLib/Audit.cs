using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Audit
    {
        public int Id { get; set; }
        public int Year { get; set; }
        //public int CompanyId { get; set; } //?????????????????????
        public Companies Company { get; set; }
        //public int AuditTypeId { get; set; } //?????????????????????
        public AuditTypes AuditType { get; set; }
        public string Title { get; set; }
        public DateTime ReportDt { get; set; }
        //public int Auditor1ID { get; set; } //?????????????????????
        public Users Auditor1 { get; set; }
        //public int? Auditor2ID { get; set; } //?????????????????????
        public Users Auditor2 { get; set; }
        //public int? SupervisorID { get; set; } //?????????????????????
        public Users Supervisor { get; set; }
        public bool IsCompleted { get; set; } //?????????????????????
        public string AuditNumber { get; set; }
        public string IASentNumber { get; set; }
        //public int AttCnt { get; set; } //?????????????????????

        //public int? AuditRatingId { get; set; } //?????????????????????
        public AuditRating AuditRating { get; set; }

        public bool IsDeleted { get; set; }

        public List<FIHeader> FIHeaders { get; set; }

        /*
        public static bool isEqual(Audit x, Audit y)
        {
            if (x.Id == y.Id && x.Year == y.Year && x.CompanyId == y.CompanyId && Companies.isEqual(x.Company, y.Company) && x.AuditTypeId == y.AuditTypeId && AuditTypes.isEqual(x.AuditType, y.AuditType) &&
                x.Title == y.Title && x.ReportDt == y.ReportDt && x.Auditor1ID == y.Auditor1ID && Users.isEqual(x.Auditor1, y.Auditor1) && x.Auditor2ID == y.Auditor2ID && Users.isEqual(x.Auditor2, y.Auditor2) &&
                x.SupervisorID == y.SupervisorID && Users.isEqual(x.Supervisor, y.Supervisor) && x.IsCompleted == y.IsCompleted && x.AuditNumber == y.AuditNumber && x.IASentNumber == y.IASentNumber && x.RevNo == y.RevNo &&
                x.AuditRatingId == y.AuditRatingId && AuditRating.isEqual(x.AuditRating, y.AuditRating))
                return true;
            else
                return false;
        }
        */

        public static BindingList<Audit> Select(bool showDeleted)
        {
            BindingList<Audit> ret = new BindingList<Audit>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A.[Id], A.[Year], A.[CompanyId], A.[AuditTypeId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , A.[Title])) as Title, " +
                              "A.[ReportDt], " +
                              "A.[Auditor1Id], A.[Auditor2Id], A.[SupervisorId], " +
                              "A.[IsCompleted], A.[AuditNumber], A.[IASentNumber], " +
                              //"(SELECT count(*) FROM [dbo].[Audit_Attachments] T WHERE a.id = T.AuditID and A.RevNo = T.RevNo) as AttCnt, " +
                              "A.[AuditRatingId], isnull(A.[IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[Audit] A ";

            if (!showDeleted)
            {
                SelectSt += "WHERE isnull(A.[IsDeleted], 'FALSE') = 'FALSE' ";
            }

            SelectSt += "ORDER BY A.Id "; //ToDo

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //int? Auditor2_Id, Supervisor_Id;
                    //int? AuditRating_Id;

                    AuditRating AuditRating_rating;
                    Users Auditor2_User, Supervisor_User;

                    if (reader["Auditor2Id"] == System.DBNull.Value)
                    {
                        //Auditor2_Id = null;
                        Auditor2_User = new Users();
                    }
                    else
                    {
                        //Auditor2_Id = Convert.ToInt32(reader["Auditor2Id"].ToString());
                        Auditor2_User = new Users(Convert.ToInt32(reader["Auditor2Id"].ToString()));
                    }
                    if (reader["SupervisorId"] == System.DBNull.Value)
                    {
                        //Supervisor_Id = null;
                        Supervisor_User = new Users();
                    }
                    else
                    {
                        //Supervisor_Id = Convert.ToInt32(reader["SupervisorId"].ToString());
                        Supervisor_User = new Users(Convert.ToInt32(reader["SupervisorId"].ToString()));
                    }
                    if (reader["AuditRatingId"] == System.DBNull.Value)
                    {
                        //AuditRating_Id = null;
                        AuditRating_rating = new AuditRating();
                    }
                    else
                    {
                        //AuditRating_Id = Convert.ToInt32(reader["AuditRatingId"].ToString());
                        AuditRating_rating = new AuditRating(Convert.ToInt32(reader["AuditRatingId"].ToString()));
                    }

                    AuditOwners auditOwners = new AuditOwners(new Users(Convert.ToInt32(reader["Auditor1Id"].ToString())), Auditor2_User, Supervisor_User);

                    ret.Add(new Audit()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Year = Convert.ToInt32(reader["Year"].ToString()),
                        //CompanyId = Convert.ToInt32(reader["CompanyId"].ToString()),
                        Company = new Companies(Convert.ToInt32(reader["CompanyId"].ToString())),
                        //AuditTypeId = Convert.ToInt32(reader["AuditTypeId"].ToString()),
                        AuditType = new AuditTypes(Convert.ToInt32(reader["AuditTypeId"].ToString())),
                        Title = reader["Title"].ToString(),
                        ReportDt = Convert.ToDateTime(reader["ReportDt"].ToString()),
                        //Auditor1ID = Convert.ToInt32(reader["Auditor1Id"].ToString()),
                        Auditor1 = new Users(Convert.ToInt32(reader["Auditor1Id"].ToString())),

                        //Auditor2ID = Auditor2_Id, //Convert.ToInt32(reader["Auditor2Id"].ToString()),
                        Auditor2 = Auditor2_User, //new Users(Convert.ToInt32(reader["Auditor2Id"].ToString())),

                        //SupervisorID = Supervisor_Id, //Convert.ToInt32(reader["SupervisorId"].ToString()),
                        Supervisor = Supervisor_User, //new Users(Convert.ToInt32(reader["SupervisorId"].ToString())),

                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"].ToString()),
                        AuditNumber = reader["AuditNumber"].ToString(),
                        IASentNumber = reader["IASentNumber"].ToString(),
                        //RevNo = Convert.ToInt32(reader["RevNo"].ToString()),
                        //AttCnt = Convert.ToInt32(reader["AttCnt"].ToString()),

                        //AuditRatingId = AuditRating_Id,
                        AuditRating = AuditRating_rating,
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString()),

                        FIHeaders = Audit.getFIHeaders(Convert.ToInt32(reader["Id"].ToString()), showDeleted, auditOwners)
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

        public static bool Insert(Audit audit) //INSERT [dbo].[Audit]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Audit] " +
                           "([Year], [CompanyID], [AuditTypeID], [Title], [ReportDt], [Auditor1ID], [Auditor2ID], [SupervisorID], [IsCompleted], [AuditNumber], " +
                           "[IASentNumber],[InsUserID],[InsDt], [AuditRatingId]) VALUES " +
                           "(@Year, @CompanyID, @AuditTypeID, encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title)), @ReportDt, @Auditor1ID, " +
                           "@Auditor2ID, @SupervisorID, @IsCompleted, @AuditNumber, @IASentNumber, @InsUserID, getDate(), @AuditRatingId) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@Year", audit.Year);
                cmd.Parameters.AddWithValue("@CompanyID", audit.Company.Id);
                cmd.Parameters.AddWithValue("@AuditTypeID", audit.AuditType.Id);
                cmd.Parameters.AddWithValue("@Title", audit.Title);
                cmd.Parameters.AddWithValue("@ReportDt", audit.ReportDt.Date);
                cmd.Parameters.AddWithValue("@Auditor1ID", audit.Auditor1.Id);

                if (audit.Auditor2.Id <= 0)
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", audit.Auditor2.Id);
                }

                if (audit.Supervisor.Id <= 0)
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", audit.Supervisor.Id);
                }
                if (audit.AuditRating.Id <= 0)
                {
                    cmd.Parameters.AddWithValue("@AuditRatingId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AuditRatingId", audit.AuditRating.Id);
                }

                cmd.Parameters.AddWithValue("@IsCompleted", audit.IsCompleted);
                cmd.Parameters.AddWithValue("@AuditNumber", audit.AuditNumber);
                cmd.Parameters.AddWithValue("@IASentNumber", audit.IASentNumber);
                //cmd.Parameters.AddWithValue("@InsUserID", user.Id);
                cmd.Parameters.AddWithValue("@InsUserID", UserInfo.userDetails.Id);

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

        public static bool Update(Audit audit)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Audit] SET [Year] = @Year, [CompanyID] = @CompanyID, [AuditTypeID] = @AuditTypeID, " +
                "[Title] = encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title))," +
                "[ReportDt] = @ReportDt, " +
                "[Auditor1ID] = @Auditor1ID, [Auditor2ID] = @Auditor2ID, [SupervisorID] = @SupervisorID, [IsCompleted] = @IsCompleted, [AuditNumber] = @AuditNumber, " +
                "[IASentNumber] = @IASentNumber, [UpdUserID] = @UpdUserID, [UpdDt] = getDate(), [AuditRatingId]= @AuditRatingId " +
                "WHERE id=@id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@id", audit.Id);
                cmd.Parameters.AddWithValue("@Year", audit.Year);
                cmd.Parameters.AddWithValue("@CompanyID", audit.Company.Id);
                cmd.Parameters.AddWithValue("@AuditTypeID", audit.AuditType.Id);
                cmd.Parameters.AddWithValue("@Title", audit.Title);
                cmd.Parameters.AddWithValue("@ReportDt", audit.ReportDt.Date);
                cmd.Parameters.AddWithValue("@Auditor1ID", audit.Auditor1.Id);

                if (audit.Auditor2.Id <= 0)
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Auditor2ID", audit.Auditor2.Id);
                }

                if (audit.Supervisor.Id <= 0)
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SupervisorID", audit.Supervisor.Id);
                }

                if (audit.AuditRating.Id <= 0)
                {
                    cmd.Parameters.AddWithValue("@AuditRatingId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AuditRatingID", audit.AuditRating.Id);
                }

                cmd.Parameters.AddWithValue("@IsCompleted", audit.IsCompleted);
                cmd.Parameters.AddWithValue("@AuditNumber", audit.AuditNumber);
                cmd.Parameters.AddWithValue("@IASentNumber", audit.IASentNumber);
                //cmd.Parameters.AddWithValue("@InsUserID", user.Id);
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

        public static bool Delete(int id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Audit] SET [IsDeleted] = 1, " +
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

        public static bool UpdateCompleted(int id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Audit] SET [IsCompleted] = 1, [UpdUserID] = @UpdUserID, [UpdDt] = getDate() " +
                "WHERE id=@id";
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

        public static List<FIDetail> getFIDetails(int HeaderId, bool showDeleted, AuditOwners auditOwners)
        {
            List<FIDetail> ret = new List<FIDetail>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT D.[Id], D.[FIHeaderId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , D.[Description])) as Description, " +
                              "D.ActionDt, " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , D.[ActionReq])) as ActionReq,  " +
                              "D.ActionCode, isnull(D.[IsClosed], 'FALSE') as IsClosed, isnull(D.[IsPublished], 'FALSE') as IsPublished, isnull(D.[IsFinalized], 'FALSE') as IsFinalized, " +
                              "isnull(D.[IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[FIDetail] D " +
                              "WHERE D.[FIHeaderId] = @HeaderId ";

            if (!showDeleted)
            {
                SelectSt += "AND isnull(D.[IsDeleted], 'FALSE') = 'FALSE' ";
            }

            SelectSt += "ORDER BY D.Id "; //ToDo

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@HeaderId", HeaderId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FIDetail tmp = new FIDetail();
                    DateTime? DetailActionDt;

                    if (reader["ActionDt"] == System.DBNull.Value)
                    {
                        DetailActionDt = null;
                    }
                    else
                    {
                        DetailActionDt = Convert.ToDateTime(reader["ActionDt"].ToString());
                    }

                    tmp = new FIDetail()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FIHeaderId = HeaderId,
                        Description = reader["Description"].ToString(),
                        ActionDt = DetailActionDt,
                        ActionReq = reader["ActionReq"].ToString(),
                        ActionCode = reader["ActionCode"].ToString(),
                        IsClosed = Convert.ToBoolean(reader["IsClosed"].ToString()),
                        IsPublished = Convert.ToBoolean(reader["IsPublished"].ToString()),
                        IsFinalized = Convert.ToBoolean(reader["IsFinalized"].ToString()),
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString()),
                        Owners = FIDetail.getOwners(Convert.ToInt32(reader["Id"].ToString()))
                    };

                    //==============================================================
                    if (UserInfo.roleDetails.IsAdmin)
                    {
                        ret.Add(tmp);
                    }
                    //owner ή το detail να είναι published (από αυτά που επιτρέπεται να δει!)
                    else if (auditOwners.IsUser_AuditOwner() || tmp.IsPublished == true)
                    {
                        ret.Add(tmp);
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

        public static List<FIHeader> getFIHeaders(int AuditId, bool showDeleted, AuditOwners auditOwners)
        {
            List<FIHeader> ret = new List<FIHeader>();
            
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT H.[Id], H.[AuditId], CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , H.[Title])) as Title, " +
                              "H.[FICategoryId], isnull(H.[IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[FIHeader] H " +
                              "WHERE H.[AuditId] = @AuditId ";

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

                cmd.Parameters.AddWithValue("@AuditId", AuditId);

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
                        AuditId = AuditId,
                        Title = reader["Title"].ToString(),

                        FICategory = fiCat,
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString()),

                        FIDetails = Audit.getFIDetails(Convert.ToInt32(reader["Id"].ToString()), showDeleted, auditOwners)
                    };

                    //==============================================================
                    if (UserInfo.roleDetails.IsAdmin)
                    {
                        ret.Add(tmp);
                    }
                    //owner ή έστω και ένα detail published (από αυτά που επιτρέπεται να δει!)
                    //αν ενα header δεν έχει details, οι υπόλοιποι auditors δεν θα δουν τίποτα...
                    else if (auditOwners.IsUser_AuditOwner() || tmp.FIDetails.Exists(i => i.IsPublished == true)) 
                    {
                        ret.Add(tmp);
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


        public bool IsDetailPublished(int headerId, int detailId)
        {
            bool ret = this.FIHeaders.Where(i => i.Id == headerId).First().FIDetails.Where(j => j.Id == detailId).First().IsPublished;

            return ret;
        }
        public bool IsDetailFinalized(int headerId, int detailId)
        {
            bool ret = this.FIHeaders.Where(i => i.Id == headerId).First().FIDetails.Where(j => j.Id == detailId).First().IsFinalized;

            return ret;
        }

        public static bool IsDetailPublished(Audit audit, int headerId, int detailId)
        {
            bool ret = audit.FIHeaders.Where(i => i.Id == headerId).First().FIDetails.Where(j => j.Id == detailId).First().IsPublished;

            return ret;
        }
        public static bool IsDetailFinalized(Audit audit, int headerId, int detailId)
        {
            bool ret = audit.FIHeaders.Where(i => i.Id == headerId).First().FIDetails.Where(j => j.Id == detailId).First().IsFinalized;

            return ret;
        }

        public static bool IsDetailPublished(FIHeader header, int detailId)
        {
            bool ret = header.FIDetails.Where(j => j.Id == detailId).First().IsPublished;

            return ret;
        }
        public static bool IsDetailFinalized(FIHeader header, int detailId)
        {
            bool ret = header.FIDetails.Where(j => j.Id == detailId).First().IsFinalized;

            return ret;
        }

        public bool AreAllDetailsOfHeaderPublished(int headerId)
        {
            bool ret = true;

            FIHeader thisHeader = this.FIHeaders.Where(i => i.Id == headerId).First();

            if (thisHeader.FIDetails is null || thisHeader.FIDetails.Count <= 0)
            {
                return false;
            }

            foreach (FIDetail thisDetail in thisHeader.FIDetails)
            {
                if (!thisDetail.IsPublished)
                {
                    return false;
                }
            }

            return ret;
        }

        public bool AreAllDetailsOfHeaderFinalized(int headerId)
        {
            bool ret = true;

            FIHeader thisHeader = this.FIHeaders.Where(i => i.Id == headerId).First();

            if (thisHeader.FIDetails is null || thisHeader.FIDetails.Count <= 0)
            {
                return false;
            }

            foreach (FIDetail thisDetail in thisHeader.FIDetails)
            {
                if (!thisDetail.IsFinalized)
                {
                    return false;
                }
            }

            return ret;
        }

        public static bool AreAllDetailsOfHeaderPublished(Audit audit, int headerId)
        {
            bool ret = true;

            FIHeader thisHeader = audit.FIHeaders.Where(i => i.Id == headerId).First();

            if (thisHeader.FIDetails is null || thisHeader.FIDetails.Count <= 0)
            {
                return false;
            }

            foreach (FIDetail thisDetail in thisHeader.FIDetails)
            {
                if (!thisDetail.IsPublished)
                {
                    return false;
                }
            }

            return ret;
        }

        public static bool AreAllDetailsOfHeaderFinalized(Audit audit, int headerId)
        {
            bool ret = true;

            FIHeader thisHeader = audit.FIHeaders.Where(i => i.Id == headerId).First();

            if (thisHeader.FIDetails is null || thisHeader.FIDetails.Count <= 0)
            {
                return false;
            }

            foreach (FIDetail thisDetail in thisHeader.FIDetails)
            {
                if (!thisDetail.IsFinalized)
                {
                    return false;
                }
            }

            return ret;
        }

        public static bool AreAllDetailsOfHeaderPublished(FIHeader header)
        {
            bool ret = true;

            if (header.FIDetails is null || header.FIDetails.Count <= 0)
            {
                return false;
            }

            foreach (FIDetail thisDetail in header.FIDetails)
            {
                if (!thisDetail.IsPublished)
                {
                    return false;
                }
            }

            return ret;
        }

        public static bool AreAllDetailsOfHeaderFinalized(FIHeader header)
        {
            bool ret = true;

            if (header.FIDetails is null || header.FIDetails.Count <= 0)
            {
                return false;
            }

            foreach (FIDetail thisDetail in header.FIDetails)
            {
                if (!thisDetail.IsFinalized)
                {
                    return false;
                }
            }

            return ret;
        }

        public bool AreAllDetailsOfAuditPublished()
        {
            bool ret = true;

            if (this.FIHeaders is null || this.FIHeaders.Count <= 0)
            {
                return false;
            }

            foreach (FIHeader thisHeader in this.FIHeaders)
            {
                if (!AreAllDetailsOfHeaderPublished(thisHeader.Id))
                {
                    return false;
                }
            }
                                             
            return ret;
        }

        public bool AreAllDetailsOfAuditFinalized()
        {
            bool ret = true;

            if (this.FIHeaders is null || this.FIHeaders.Count <= 0)
            {
                return false;
            }

            foreach (FIHeader thisHeader in this.FIHeaders)
            {
                if (!AreAllDetailsOfHeaderFinalized(thisHeader.Id))
                {
                    return false;
                }
            }

            return ret;
        }

        public static bool AreAllDetailsOfAuditPublished(Audit audit)
        {
            bool ret = true;

            if (audit.FIHeaders is null || audit.FIHeaders.Count <= 0)
            {
                return false;
            }

            foreach (FIHeader thisHeader in audit.FIHeaders)
            {
                if (!AreAllDetailsOfHeaderPublished(thisHeader))
                {
                    return false;
                }
            }

            return ret;
        }

        public static bool AreAllDetailsOfAuditFinalized(Audit audit)
        {
            bool ret = true;

            if (audit.FIHeaders is null || audit.FIHeaders.Count <= 0)
            {
                return false;
            }

            foreach (FIHeader thisHeader in audit.FIHeaders)
            {
                if (!AreAllDetailsOfHeaderFinalized(thisHeader))
                {
                    return false;
                }
            }

            return ret;
        }
    }
}
