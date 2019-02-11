using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class Notifications
    {

        public Notifications()
        {
        }

        public static List<Notif1Obj> firstNotification()
        {
            List<Notif1Obj> ret = new List<Notif1Obj>();

            //int detailId = 0;
            //int placeholderId = 0;
            //Placeholders placeholder = new Placeholders(); 
            //DateTime? actionDt = null;
            //int userId = 0;
            //Users user = new Users();
            //----------------------------------------------------

            //--M.T. / 1 φορά κάθε 1η / Όσα λήγουν στο μήνα αυτό
            //--*****Αν δεν έχει στείλει απάντηση *****
            //-------------------------------------------

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string SelectSt =
            "SELECT D.Id as DetailId, D.ActionDt, P.PlaceholderId, U.Id as UserId " +
            //"       convert(varchar(500), decryptByPassPhrase(@passPhrase', U.FullName)) as FullName, " +
            //"       convert(varchar(500), decryptByPassPhrase(@passPhrase, U.Email)) as Email " +
            "FROM [dbo].[Audit] A left outer join " +
            "     [dbo].[FIHeader] H on A.Id = H.AuditId left outer join " +
            "     [dbo].[FIDetail] D on H.Id = D.FIHeaderId left outer join " +
            "     [dbo].[FIDetail_Placeholders] P on D.Id = P.FIDetailId left outer join " +
            "     [dbo].[Owners_MT] O on O.PlaceholderId = P.PlaceholderId left outer join " +
            "     [dbo].[Users] U on U.Id = O.UserId " +
            "WHERE isnull(A.IsDeleted, 0) = 0 AND isnull(H.IsDeleted, 0) = 0 AND isnull(D.IsDeleted, 0) = 0 AND " +
            "      D.IsPublished = 1 AND isnull(D.IsFinalized,0) = 0 AND " +
            "      year(D.ActionDt) = year(getdate()) and month(D.ActionDt) = month(getdate()) AND O.IsCurrent = 1 AND " +
            "      (SELECT top(1) D2.[ActionSideId] " +
            "      FROM [dbo].[FIDetail_Activity] A2 left outer join[dbo].[Activity_Descriptions] D2 on A2.ActivityDescriptionId = D2.Id " +
            "      WHERE A2.DetailId = D.Id AND A2.PlaceholderId = P.PlaceholderId AND D2.ActionSideId <> 3 " +
            "      ORDER BY A2.InsDt Desc) = 2 " +
            "ORDER BY U.Id, D.ActionDt ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                //cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Notif1Obj()
                    {
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        ActionDt = Convert.ToDateTime(reader["ActionDt"].ToString()),
                        Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString()))
                    });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

                //Log file...
            }

            //export a list 
            //----------------------------------------------------

            //ActionSide actSide = FIDetailActivity.getActionSide_forAuditees(detailId, placeholder.Id);

            //if (actSide.Id == 2) //auditees
            //{
            //add to a list to group emails by user/ or send one for each detail

            //and send emails
            //}

            return ret;
        }

        public static List<Notif1Obj> secondNotification()
        {
            List<Notif1Obj> ret = new List<Notif1Obj>();

            //int detailId = 0;
            //int placeholderId = 0;
            //Placeholders placeholder = new Placeholders(); 
            //DateTime? actionDt = null;
            //int userId = 0;
            //Users user = new Users();
            //----------------------------------------------------

            //--M.T., G.M., C.A.E. / 1 φορά κάθε 1η / Όσα έληξαν
            //--*****Αν δεν έχει στείλει απάντηση *****
            //-------------------------------------------

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string SelectSt =
            "SELECT D.Id as DetailId, D.ActionDt, P.PlaceholderId, U.Id as UserId " +
            //"       convert(varchar(500), decryptByPassPhrase(@passPhrase', U.FullName)) as FullName, " +
            //"       convert(varchar(500), decryptByPassPhrase(@passPhrase, U.Email)) as Email " +
            "FROM [dbo].[Audit] A left outer join " +
            "     [dbo].[FIHeader] H on A.Id = H.AuditId left outer join " +
            "     [dbo].[FIDetail] D on H.Id = D.FIHeaderId left outer join " +
            "     [dbo].[FIDetail_Placeholders] P on D.Id = P.FIDetailId left outer join " +
            "     [dbo].[Owners_MT] O on O.PlaceholderId = P.PlaceholderId left outer join " +
            "     [dbo].[Users] U on U.Id = O.UserId " +
            "WHERE isnull(A.IsDeleted, 0) = 0 AND isnull(H.IsDeleted, 0) = 0 AND isnull(D.IsDeleted, 0) = 0 AND " +
            "      D.IsPublished = 1 AND isnull(D.IsFinalized,0) = 0 AND " +
            "      D.ActionDt < @actionDt AND O.IsCurrent = 1 AND " +
            "      (SELECT top(1) D2.[ActionSideId] " +
            "      FROM [dbo].[FIDetail_Activity] A2 left outer join[dbo].[Activity_Descriptions] D2 on A2.ActivityDescriptionId = D2.Id " +
            "      WHERE A2.DetailId = D.Id AND A2.PlaceholderId = P.PlaceholderId AND D2.ActionSideId <> 3 " +
            "      ORDER BY A2.InsDt Desc) = 2 " +
            "ORDER BY U.Id, D.ActionDt ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                DateTime actionDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                
                cmd.Parameters.AddWithValue("@actionDt", actionDt);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Notif1Obj()
                    {
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        ActionDt = Convert.ToDateTime(reader["ActionDt"].ToString()),
                        Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString()))
                    });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

                //Log file...
            }

            //export a list 
            //----------------------------------------------------

            //ActionSide actSide = FIDetailActivity.getActionSide_forAuditees(detailId, placeholder.Id);

            //if (actSide.Id == 2) //auditees
            //{
            //add to a list to group emails by user/ or send one for each detail

            //and send emails
            //}

            return ret;
        }

        public static List<Notif1Obj> thirdNotification()
        {
            List<Notif1Obj> ret = new List<Notif1Obj>();

            //int detailId = 0;
            //int placeholderId = 0;
            //Placeholders placeholder = new Placeholders(); 
            //DateTime? actionDt = null;
            //int userId = 0;
            //Users user = new Users();
            //----------------------------------------------------

            //--Auditors 1,2 / 1 φορά κάθε μέρα / Όσα θα λήξουν σε 15 μέρες
            //--*****Αν δεν έχει στείλει απάντηση *****
            //-------------------------------------------

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string SelectSt =
            "SELECT D.Id as DetailId, D.ActionDt, P.PlaceholderId, U.Id as UserId " +
            //"       convert(varchar(500), decryptByPassPhrase(@passPhrase', U.FullName)) as FullName, " +
            //"       convert(varchar(500), decryptByPassPhrase(@passPhrase, U.Email)) as Email " +
            "FROM [dbo].[Audit] A left outer join " +
            "     [dbo].[FIHeader] H on A.Id = H.AuditId left outer join " +
            "     [dbo].[FIDetail] D on H.Id = D.FIHeaderId left outer join " +
            "     [dbo].[FIDetail_Placeholders] P on D.Id = P.FIDetailId left outer join " +
            "     [dbo].[Owners_MT] O on O.PlaceholderId = P.PlaceholderId left outer join " +
            "     [dbo].[Users] U on U.Id = O.UserId " +
            "WHERE isnull(A.IsDeleted, 0) = 0 AND isnull(H.IsDeleted, 0) = 0 AND isnull(D.IsDeleted, 0) = 0 AND " +
            "      D.IsPublished = 1 AND isnull(D.IsFinalized,0) = 0 AND " +
            "      D.ActionDt > convert(date, getdate()) AND D.ActionDt < DATEADD(day, 15, convert(date, getdate())) AND O.IsCurrent = 1 AND " +
            "      (SELECT top(1) D2.[ActionSideId] " +
            "      FROM [dbo].[FIDetail_Activity] A2 left outer join[dbo].[Activity_Descriptions] D2 on A2.ActivityDescriptionId = D2.Id " +
            "      WHERE A2.DetailId = D.Id AND A2.PlaceholderId = P.PlaceholderId AND D2.ActionSideId <> 3 " +
            "      ORDER BY A2.InsDt Desc) = 2 " +
            "ORDER BY U.Id, D.ActionDt ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                DateTime actionDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                cmd.Parameters.AddWithValue("@actionDt", actionDt);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Notif1Obj()
                    {
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        ActionDt = Convert.ToDateTime(reader["ActionDt"].ToString()),
                        Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString())),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString()))
                    });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

                //Log file...
            }

            //export a list 
            //----------------------------------------------------

            //ActionSide actSide = FIDetailActivity.getActionSide_forAuditees(detailId, placeholder.Id);

            //if (actSide.Id == 2) //auditees
            //{
            //add to a list to group emails by user/ or send one for each detail

            //and send emails
            //}

            return ret;
        }

        public static List<Notif1Obj> fourthNotification()
        {
            List<Notif1Obj> ret = new List<Notif1Obj>();

            //int detailId = 0;
            //int placeholderId = 0;
            //Placeholders placeholder = new Placeholders(); 
            //DateTime? actionDt = null;
            //int userId = 0;
            //Users user = new Users();
            //----------------------------------------------------

            //--C.A.E. / 1 φορά κάθε μέρα / Όσα στις 15 ημέρες δεν έχουν ενέργεια από Auditor1,2 ή Supervisor
            //--*****Αν δεν έχει στείλει απάντηση *****
            //-------------------------------------------

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string SelectSt =
            "SELECT D.Id as DetailId, D.ActionDt, A.Auditor1ID, A.Auditor2ID, A.SupervisorID " +
            "FROM [dbo].[Audit] A left outer join " +
            "     [dbo].[FIHeader] H on A.Id = H.AuditId left outer join " +
            "     [dbo].[FIDetail] D on H.Id = D.FIHeaderId " +
            "WHERE isnull(A.IsDeleted, 0) = 0 AND isnull(H.IsDeleted, 0) = 0 AND isnull(D.IsDeleted, 0) = 0 AND " +
            "      D.IsPublished = 1 AND isnull(D.IsFinalized,0) = 0 ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                DateTime actionDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                cmd.Parameters.AddWithValue("@actionDt", actionDt);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Notif1Obj notObj = new Notif1Obj();

                    notObj.DetailId = Convert.ToInt32(reader["DetailId"].ToString());
                    if (reader["ActionDt"] != DBNull.Value)
                    {
                        notObj.ActionDt = Convert.ToDateTime(reader["ActionDt"].ToString());
                    }
                    else
                    {
                        notObj.ActionDt = null;
                    }
                    //notObj.Placeholder = new Placeholders(Convert.ToInt32(reader["PlaceholderId"].ToString()));
                    //User = new Users(Convert.ToInt32(reader["UserId"].ToString()))

                    notObj.Auditor1 = new Users(Convert.ToInt32(reader["Auditor1ID"].ToString()));
                    if (reader["Auditor2ID"] != DBNull.Value)
                    {
                        notObj.Auditor2 = new Users(Convert.ToInt32(reader["Auditor2ID"].ToString()));
                    }
                    else
                    {
                        notObj.Auditor2 = new Users();
                    }
                    if (reader["SupervisorID"] != DBNull.Value)
                    {
                        notObj.Supervisor = new Users(Convert.ToInt32(reader["SupervisorID"].ToString()));
                    }
                    else
                    {
                        notObj.Supervisor = new Users();
                    }

                    if (FIDetailActivity.getActionSide_forAuditors(new FIDetail(notObj.DetailId)).Id == 1) //IA for all placeholders
                    {
                        bool auditor1Added = false;
                        bool auditor2Added = false;
                        DateTime? LastPublishDateFromMT = FIDetailActivity.LastPublishDateFromMTtoIA(notObj.DetailId);
                        DateTime? MaxAuditorVotingDate = null;

                        if (notObj.Auditor1.Id > 0)  
                        {
                            DateTime? VotingDate = FIDetailVoting.VotingDate_ifHasAlreadyVoted(notObj.DetailId, notObj.Auditor1.Id);
                            if (VotingDate is null)                            
                            {
                                //check 15 days period from last MT's publishing
                                if (LastPublishDateFromMT != null && ((DateTime)LastPublishDateFromMT).AddDays(15) < DateTime.Now)
                                {
                                    //add to list
                                    notObj.Auditor1Idle = true;
                                    ret.Add(notObj);

                                    auditor1Added = true;
                                }
                            }
                            else
                            {
                                //get voting date
                                MaxAuditorVotingDate = VotingDate;
                            }
                        }

                        if (notObj.Auditor2.Id > 0) 
                        {
                            DateTime? VotingDate = FIDetailVoting.VotingDate_ifHasAlreadyVoted(notObj.DetailId, notObj.Auditor2.Id);
                            if (VotingDate is null)
                            {
                                //check 15 days period from last MT's publishing
                                if (LastPublishDateFromMT != null && ((DateTime)LastPublishDateFromMT).AddDays(15) < DateTime.Now)
                                {
                                    //add to list
                                    notObj.Auditor2Idle = true;
                                    ret.Add(notObj);

                                    auditor2Added = true;
                                }
                            }
                            else
                            {
                                //get voting date
                                if (((DateTime)VotingDate) > ((DateTime)MaxAuditorVotingDate))
                                {
                                    MaxAuditorVotingDate = VotingDate;
                                }
                            }
                        }

                        //auditors1, 2 must vote first
                        if (auditor1Added || auditor2Added)
                        {
                            continue;
                        }
                        
                        if (notObj.Supervisor.Id > 0 && FIDetailVoting.HasAlreadyVoted(notObj.DetailId, notObj.Supervisor.Id) == false)
                        {
                            //check 15 days period from last Auditor(1,2) voting
                            if (((DateTime)MaxAuditorVotingDate).AddDays(15) < DateTime.Now)
                            {
                                //add to list
                                notObj.SupervisorIdle = true;
                                ret.Add(notObj);
                            }
                        }

                    }

                    
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

                //Log file...
            }

            //export a list 
            //----------------------------------------------------

            //ActionSide actSide = FIDetailActivity.getActionSide_forAuditees(detailId, placeholder.Id);

            //if (actSide.Id == 2) //auditees
            //{
            //add to a list to group emails by user/ or send one for each detail

            //and send emails
            //}

            return ret;
        }
    }

    public class Notif1Obj
    {
        public int DetailId { get; set; }
        public DateTime? ActionDt { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public Users Auditor1 { get; set; }
        public bool Auditor1Idle { get; set; }
        public Users Auditor2 { get; set; }
        public bool Auditor2Idle { get; set; }
        public Users Supervisor { get; set; }
        public bool SupervisorIdle { get; set; }
        public Notif1Obj()
        {

        }
    }

}
