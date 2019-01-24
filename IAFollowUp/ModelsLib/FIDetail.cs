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
    public class FIDetail
    {
        public int Id { get; set; }
        public string Description { get; set; } //*
        public int FIHeaderId { get; set; }
        public DateTime? ActionDt { get; set; } //
        public string ActionReq { get; set; } //
        public string ActionCode { get; set; } //the only mandatory field!!!
        //public List<Users> Owners { get; set; } //

        public List<Placeholders> Placeholders { get; set; }
               

        public Owners_MT CurrentOwner1 { get; set; }
        public Owners_MT CurrentOwner2 { get; set; }
        public Owners_MT CurrentOwner3 { get; set; }


        public Owners_MT RealOwner1 { get; set; }
        public Owners_MT RealOwner2 { get; set; }
        public Owners_MT RealOwner3 { get; set; }

        //public int OwnersCnt { get; set; }

        //public int InsUserId { get; set; }
        //public Users InsUser { get; set; }
        //public DateTime InsDt { get; set; }
        //public int UpdUserId { get; set; }
        //public Users UpdUser { get; set; }
        //public DateTime UpdDt { get; set; }

        //public int AttCnt { get; set; }

        public bool IsClosed { get; set; }

        public bool IsPublished { get; set; }
        public bool IsFinalized { get; set; }

        public bool IsDeleted { get; set; }
        public string FISubId { get; set; }

        public FIDetail()
        {
            //Owners = new List<Users>();
            Placeholders = new List<Placeholders>();
            
            CurrentOwner1 = new Owners_MT();
            CurrentOwner2 = new Owners_MT();
            CurrentOwner3 = new Owners_MT();

            RealOwner1 = new Owners_MT();
            RealOwner2 = new Owners_MT();
            RealOwner3 = new Owners_MT();
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

        /*
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
        */

        public static List<Placeholders> getOwners(int detail_Id)
        {
            List<Placeholders> ret = new List<Placeholders>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [PlaceholderId] " +
                              "FROM [dbo].[FIDetail_Placeholders] " +
                              "WHERE FIDetailId = @detail_Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detail_Id", detail_Id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())));
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

        private static bool InsertIntoTable_FIDetailPlaceholders(int fiDetailId, Placeholders SinglePlaceholder) //INSERT [dbo].[FIDetail_Placeholders]
        {
            bool ret = false;

            //dgvOwners.Rows.Add(new object[] { thisOwner.Id, thisOwner.FullName, thisOwner.RoleName });
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Placeholders] ([FIDetailId], [PlaceholderId]) " +
                           "VALUES (@DetailId, @PlaceholderId) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@DetailId", fiDetailId);
                cmd.Parameters.AddWithValue("@PlaceholderId", SinglePlaceholder.Id);
                
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
            string InsSt = "INSERT INTO [dbo].[FIDetail] ([FIHeaderId], [Description], [ActionReq], [ActionDt], [ActionCode], [IsClosed], [FISubId], [InsUserId], [InsDt] ) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES " +
                           "(@HeaderId, encryptByPassPhrase(@passPhrase, convert(varchar(500), @Description)), encryptByPassPhrase(@passPhrase, convert(varchar(500), @ActionReq))," +
                           "@ActionDt, @ActionCode, @IsClosed, @FISubId, @InsUserId, getDate()) ";
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

                cmd.Parameters.AddWithValue("@IsClosed", fiDetail.IsClosed);
                cmd.Parameters.AddWithValue("@FISubId", fiDetail.FISubId);

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

                    //foreach (Users thisOwner in fiDetail.Owners)
                    //{
                    //    if (!InsertIntoTable_FIDetailOwners(fiDetail.Id, thisOwner))
                    //    {
                    //        ret = false;
                    //    }
                    //}

                    foreach (Placeholders thisPlaceholder in fiDetail.Placeholders)
                    {
                        if (!InsertIntoTable_FIDetailPlaceholders(fiDetail.Id, thisPlaceholder))
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

        /*
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
        */

        public static bool DeleteOwners(int detailId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[FIDetail_Placeholders] WHERE FIDetailId = @FIDetailId ";
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
                          "[IsClosed] = @IsClosed, [FISubId] = @FISubId, [UpdUserId] = @UpdUserId, [UpdDt] = getDate() " +
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
                cmd.Parameters.AddWithValue("@IsClosed", detail.IsClosed);
                cmd.Parameters.AddWithValue("@FISubId", detail.FISubId);
                cmd.Parameters.AddWithValue("@UpdUserId", UserInfo.userDetails.Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;

                    //delete old Owners

                    //if (!DeleteOwners(detail.Id))
                    //{
                    //    ret = false;
                    //}

                    //foreach (Users thisOwner in detail.Owners)
                    //{
                    //    if (!InsertIntoTable_FIDetailOwners(detail.Id, thisOwner))
                    //    {
                    //        ret = false;
                    //    }
                    //}

                    if (!DeleteOwners(detail.Id))
                    {
                        ret = false;
                    }

                    foreach (Placeholders thisPlaceholder in detail.Placeholders)
                    {
                        if (!InsertIntoTable_FIDetailPlaceholders(detail.Id, thisPlaceholder))
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

        public static bool Delete(int id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [IsDeleted] = 1, " +
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

        public static bool PublishSingle(FIDetail detail)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [IsPublished] = 'TRUE', [UpdUserId] = @UpdUserId, [UpdDt] = getDate() " +
                "WHERE Id = @detailId AND isnull([IsDeleted], 'FALSE') = 'FALSE' ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@detailId", detail.Id);

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

        //public static List<FIDetail> PublishAll(FIHeader header)
        //{
        //    List<FIDetail> ret = new List<FIDetail>();

        //    foreach (FIDetail detail in header.FIDetails)
        //    {
        //        if (detail.IsDeleted == false)
        //        {
        //            if (PublishSingle(detail))
        //            {
        //                ChangeLog.Insert(new FIDetail() { Id = detail.Id, IsPublished = detail.IsPublished }, new FIDetail() { Id = detail.Id, IsPublished = true }, "FIDetail");
        //                ret.Add(detail);
        //            }
        //        }
        //    }

        //    return ret;
        //}

        public static List<FIDetail> PublishAll(Audit audit)
        {
            List<FIDetail> ret = new List<FIDetail>();

            List<FIHeader> headerList = audit.FIHeaders.Where(i => i.IsDeleted == false).ToList();

            foreach (FIHeader header in headerList)
            {
                foreach (FIDetail detail in header.FIDetails)
                {
                    if (detail.IsDeleted == false)
                    {
                        if (PublishSingle(detail))
                        {
                            ChangeLog.Insert(new FIDetail() { Id = detail.Id, IsPublished = detail.IsPublished }, new FIDetail() { Id = detail.Id, IsPublished = true }, "FIDetail");
                            ret.Add(detail);

                            //1st Activity: IA Published to MT
                            FIDetailActivity detActivity = new FIDetailActivity();
                            detActivity.DetailId = detail.Id;
                            detActivity.ActivityDescription = new ActivityDescription(1);
                            detActivity.ActionDt = FIDetail.getActionDate(detail.Id);
                            

                            if (detail.Placeholders.Count >= 1 && detail.Placeholders[0] != null)
                            {
                                //detail.CurrentOwner1 = DetailOwners.GetCurrentDetailOwner(detail.Placeholders[0].Id);
                                FIDetail.Update_FIDetailPlaceholders_RealOwner(detail.Id, detail.Placeholders[0].Id, detail.CurrentOwner1.User.Id);

                                detActivity.ToUser = detail.CurrentOwner1.User;
                                detActivity.Placeholders = detail.Placeholders[0];
                                FIDetailActivity.Insert(detActivity);
                            }
                            if (detail.Placeholders.Count >= 2 && detail.Placeholders[1] != null)
                            {
                                //detail.CurrentOwner2 = DetailOwners.GetCurrentDetailOwner(detail.Placeholders[1].Id);
                                FIDetail.Update_FIDetailPlaceholders_RealOwner(detail.Id, detail.Placeholders[1].Id, detail.CurrentOwner2.User.Id);

                                detActivity.ToUser = detail.CurrentOwner2.User;
                                detActivity.Placeholders = detail.Placeholders[1];
                                FIDetailActivity.Insert(detActivity);
                            }
                            if (detail.Placeholders.Count >= 3 && detail.Placeholders[2] != null)
                            {
                                //detail.CurrentOwner3 = DetailOwners.GetCurrentDetailOwner(detail.Placeholders[2].Id);
                                FIDetail.Update_FIDetailPlaceholders_RealOwner(detail.Id, detail.Placeholders[2].Id, detail.CurrentOwner3.User.Id);

                                detActivity.ToUser = detail.CurrentOwner3.User;
                                detActivity.Placeholders = detail.Placeholders[2];
                                FIDetailActivity.Insert(detActivity);
                            }

                           
                            


                        }
                    }
                }
            }

            return ret;
        }

        public static bool Update_FIDetailPlaceholders_RealOwner(int detailId, int placeholderId, int currentOwnerId) //UPDATE [dbo].[FIDetail_Placeholders]
        {
            bool ret = false;

            //dgvOwners.Rows.Add(new object[] { thisOwner.Id, thisOwner.FullName, thisOwner.RoleName });
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail_Placeholders] SET [RealOwnerId] = @RealOwnerId " +
                           "WHERE [FIDetailId] = @DetailId AND [PlaceholderId] = @PlaceholderId ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@DetailId", detailId);
                cmd.Parameters.AddWithValue("@PlaceholderId", placeholderId);
                cmd.Parameters.AddWithValue("@RealOwnerId", currentOwnerId);

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

        public static bool Finalize(int detailId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [IsFinalized] = 'TRUE', [UpdUserId] = @UpdUserId, [UpdDt] = getDate() " +
                "WHERE Id = @detailId ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@detailId", detailId);

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

        public static List<FIDetail> Select(bool showDeleted)
        {
            List<FIDetail> ret = new List<FIDetail>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT D.[Id], D.[FIHeaderId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , D.[Description])) as Description, " +
                              "D.ActionDt, " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , D.[ActionReq])) as ActionReq,  " +
                              "D.ActionCode, isnull(D.[IsClosed], 'FALSE') as IsClosed, isnull(D.[IsPublished], 'FALSE') as IsPublished, isnull(D.[IsFinalized], 'FALSE') as IsFinalized, " +
                              "isnull(D.[IsDeleted], 'FALSE') as IsDeleted, D.[FISubId] " +
                              "FROM [dbo].[FIDetail] D ";

            if (!showDeleted)
            {
                SelectSt += "WHERE isnull(D.[IsDeleted], 'FALSE') = 'FALSE' ";
            }

            SelectSt += "ORDER BY D.Id "; //ToDo

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

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
                        FIHeaderId = Convert.ToInt32(reader["FIHeaderId"].ToString()),
                        Description = reader["Description"].ToString(),
                        ActionDt = DetailActionDt,
                        ActionReq = reader["ActionReq"].ToString(),
                        ActionCode = reader["ActionCode"].ToString(),
                        IsClosed = Convert.ToBoolean(reader["IsClosed"].ToString()),
                        IsPublished = Convert.ToBoolean(reader["IsPublished"].ToString()),
                        IsFinalized = Convert.ToBoolean(reader["IsFinalized"].ToString()),
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString()),
                        //Owners = FIDetail.getOwners(Convert.ToInt32(reader["Id"].ToString()))
                        Placeholders = FIDetail.getOwners(Convert.ToInt32(reader["Id"].ToString())),
                        FISubId = reader["FISubId"].ToString()
                    };

                    //==============================================================
                    //-> Management Team Users
                    List<Users> usersListMT = new List<Users>();
                    foreach (Placeholders ph in tmp.Placeholders)
                    {
                        usersListMT.Add(Owners_MT.GetCurrentOwnerMT(ph.Id).User);
                    }
                    FIDetailOwners detailOwnersMT = new FIDetailOwners(usersListMT);
                    //<- Management Team Users

                    //-> General Managers
                    List<Users> usersListGM = new List<Users>();
                    foreach (Placeholders ph in tmp.Placeholders)
                    {
                        usersListGM.AddRange(Owners_GM.GetOwnerGMUsersList(ph.Id));
                    }
                    FIDetailOwners detailOwnersGM = new FIDetailOwners(usersListGM);
                    //<- General Managers

                    //-> Delegatees
                    List<Users> usersListDT = new List<Users>();
                    foreach (Placeholders ph in tmp.Placeholders)
                    {
                        usersListDT.AddRange(Owners_DT.GetOwnerDTUsersList(tmp.Id, ph.Id));
                    }
                    FIDetailOwners detailOwnersDT = new FIDetailOwners(usersListDT);
                    //<- Delegatees

                    //a) Admin - All
                    if (UserInfo.roleDetails.IsAdmin)
                    {
                        ret.Add(tmp);
                        continue;
                    }

                    //b) Auditor - Published
                    if (UserInfo.roleDetails.IsAuditor)
                    {
                        if (tmp.IsPublished)
                        {
                            ret.Add(tmp);
                            continue;
                        }
                    }

                    //c) MT (placeholder's current owner) - Published
                    if (detailOwnersMT.IsUser_DetailOwner())
                    {
                        if (tmp.IsPublished)
                        {
                            ret.Add(tmp);
                            continue;
                        }
                    }

                    //d) GM (placeholder's owner) - Published
                    if (detailOwnersGM.IsUser_DetailOwner())
                    {
                        if (tmp.IsPublished)
                        {
                            ret.Add(tmp);
                            continue;
                        }
                    }

                    //e) DT (placeholder's delegatees) - Published
                    if (detailOwnersDT.IsUser_DetailOwner())
                    {
                        if (tmp.IsPublished)
                        {
                            ret.Add(tmp);
                            continue;
                        }
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

        public static int FinalizeClosed(List<FIDetail> detailList)
        {
            int ret = 0;

            foreach (FIDetail detail in detailList)
            {
                if (Finalize(detail.Id))
                {
                    ret++;
                }
            }

            return ret;
        }

        public static AuditOwners getAuditOwners(int detailId)
        {
            AuditOwners ret = new AuditOwners();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A.Auditor1ID, A.Auditor2ID, A.SupervisorID " +
                              "FROM [dbo].[FIDetail] D left outer join " +
                              "     [dbo].[FIHeader] H on D.FIHeaderId = H.Id left outer join " +
                              "     [dbo].[Audit] A on H.AuditId = A.Id " +
                              "WHERE D.Id = @detailId";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detailId", detailId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
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
                    
                    ret = new AuditOwners(new Users(Convert.ToInt32(reader["Auditor1Id"].ToString())), Auditor2_User, Supervisor_User);
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

        public static DateTime? getActionDate(int detailId)
        {
            DateTime? ret = null;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT ActionDt " +
                              "FROM [dbo].[FIDetail] " +
                              "WHERE Id = @detailId";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detailId", detailId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ActionDt"] == System.DBNull.Value)
                    {
                        ret = null;
                    }
                    else
                    {
                        ret = Convert.ToDateTime(reader["ActionDt"].ToString());
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

        public static bool UpdateActionDate(int detailId, DateTime newActionDate)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail] SET [ActionDt] = '@actionDt', [UpdUserId] = @UpdUserId, [UpdDt] = getDate() " +
                "WHERE Id = @detailId ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@detailId", detailId);
                cmd.Parameters.AddWithValue("@actionDt", newActionDate);
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

    }
}
