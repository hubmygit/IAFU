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
        public ActivityDescription ActivityDescription { get; set; } 
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

        public static List<FIDetailActivity> Select(int detailId)
        {
            List<FIDetailActivity> ret = new List<FIDetailActivity>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DetailId], [ActivityDescriptionId], [FromUserId], [ToUserId], [InsDt] " +
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

                    tmp = new FIDetailActivity();
                    
                    tmp.Id = Convert.ToInt32(reader["Id"].ToString());
                    tmp.DetailId = Convert.ToInt32(reader["DetailId"].ToString());
                    tmp.ActivityDescription = new ActivityDescription(Convert.ToInt32(reader["ActivityDescriptionId"].ToString()));
                    if (reader["FromUserId"] == DBNull.Value)
                    {
                        tmp.FromUser = new Users();
                    }
                    else
                    {
                        tmp.FromUser = new Users(Convert.ToInt32(reader["FromUserId"].ToString()));
                    }
                    if (reader["ToUserId"] == DBNull.Value)
                    {
                        tmp.ToUser = new Users();
                    }
                    else
                    {
                        tmp.ToUser = new Users(Convert.ToInt32(reader["ToUserId"].ToString()));
                    }
                    tmp.InsDt = Convert.ToDateTime(reader["InsDt"].ToString());

                    List<Placeholders> placeholders = FIDetail.getOwners(tmp.DetailId);
                  
                    //==============================================================
                    //-> Management Team Users
                    List<Users> usersListMT = new List<Users>();
                    foreach (Placeholders ph in placeholders)
                    {
                        usersListMT.Add(Owners_MT.GetCurrentOwnerMT(ph.Id).User);
                    }
                    FIDetailOwners detailOwnersMT = new FIDetailOwners(usersListMT);
                    //<- Management Team Users

                    //-> General Managers
                    List<Users> usersListGM = new List<Users>();
                    foreach (Placeholders ph in placeholders)
                    {
                        usersListGM.AddRange(Owners_GM.GetOwnerGMUsersList(ph.Id));
                    }
                    FIDetailOwners detailOwnersGM = new FIDetailOwners(usersListGM);
                    //<- General Managers

                    //-> Delegatees
                    List<Users> usersListDT = new List<Users>();
                    foreach (Placeholders ph in placeholders)
                    {
                        usersListDT.AddRange(Owners_DT.GetOwnerDTUsersList(tmp.Id, ph.Id));
                    }
                    FIDetailOwners detailOwnersDT = new FIDetailOwners(usersListDT);
                    //<- Delegatees

                    //a) Admin - All
                    if (UserInfo.roleDetails.IsAdmin)
                    {
                        ret.Add(tmp);
                    }
                    //b) Auditor(All) - Exists into From or To
                    else if (UserInfo.roleDetails.IsAuditor)
                    {
                        if (tmp.ActivityDescription.IsIaAction) //Επειδή δεν αναφέρεται όνομα στους IA, κοιτάω αν πρόκειται για action από/προς IA..
                        {
                            ret.Add(tmp);
                        }
                    }
                    //c) MT(placeholder's current owner) - Exists into From or To
                    else if (detailOwnersMT.IsUser_DetailOwner())
                    {
                        if (UserInfo.userDetails.Id == tmp.FromUser.Id || UserInfo.userDetails.Id == tmp.ToUser.Id)
                        {
                            ret.Add(tmp);
                        }
                    }
                    //d) GM (placeholder's owner) - Exists into From or To
                    else if (detailOwnersGM.IsUser_DetailOwner())
                    {
                        //gia kathe placeholder toy detail
                        foreach (Placeholders ph in placeholders)
                        {
                            //vres ton mt toy placeholder
                            Users MTofPH = Owners_MT.GetCurrentOwnerMT(ph.Id).User;

                            //an o mt einai sto from/to 
                            if (MTofPH.Id == tmp.FromUser.Id || MTofPH.Id == tmp.ToUser.Id)
                            {
                                //an gia auto to placeholder anikw stoys gm toy
                                List<Users> PhGmList = Owners_GM.GetOwnerGMUsersList(ph.Id); //poioi einai oi GmOwners tou placeholder                                
                                FIDetailOwners PhDetailOwnersGM = new FIDetailOwners(PhGmList);
                                if (PhDetailOwnersGM.IsUser_DetailOwner()) //anikw se autous
                                {
                                    ret.Add(tmp);
                                }
                            }
                        }
                    }
                    //e) DT (placeholder's delegatees) - Exists into From or To
                    else if (detailOwnersDT.IsUser_DetailOwner())
                    {
                        if (UserInfo.userDetails.Id == tmp.FromUser.Id || UserInfo.userDetails.Id == tmp.ToUser.Id)
                        {
                            ret.Add(tmp);
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

        public static bool Insert(FIDetailActivity fiDetailActivity) //INSERT [dbo].[FIDetail_Activity]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Activity] ([DetailId], [ActivityDescriptionId], [CommentText], [CommentRtf], " + 
                                       "[FromUserId], [ToUserId], [IsPublic], [InsUserId], [InsDt]) VALUES " +
                           "(@DetailId, @ActivityDescriptionId, @CommentText, @CommentRtf, @FromUserId, @ToUserId, @IsPublic, @InsUserId, getDate())"; 
            //encryptByPassPhrase(@passPhrase, convert(varchar(500), @Title)), " +

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@DetailId", fiDetailActivity.DetailId);
                cmd.Parameters.AddWithValue("@ActivityDescriptionId", fiDetailActivity.ActivityDescription.Id);

                if (fiDetailActivity.CommentText is null || fiDetailActivity.CommentText.Trim() == "")
                {
                    cmd.Parameters.AddWithValue("@CommentText", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CommentRtf", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CommentText", fiDetailActivity.CommentText);
                    cmd.Parameters.AddWithValue("@CommentRtf", fiDetailActivity.CommentRtf);
                }

                if (fiDetailActivity.FromUser != null && fiDetailActivity.FromUser.Id > 0)
                {
                    cmd.Parameters.AddWithValue("@FromUserId", fiDetailActivity.FromUser.Id); //UserInfo.userDetails.Id);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FromUserId", DBNull.Value);
                }

                if (fiDetailActivity.ToUser != null && fiDetailActivity.ToUser.Id > 0)
                {
                    cmd.Parameters.AddWithValue("@ToUserId", fiDetailActivity.ToUser.Id);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ToUserId", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@IsPublic", true);
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

    }
}
