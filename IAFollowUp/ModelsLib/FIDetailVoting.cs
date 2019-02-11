using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public class FIDetailVoting
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public Users User { get; set; }
        public AuditorsRoles AuditorRole { get; set; }
        public Classification Classification { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime InsDate { get; set; }

        public FIDetailVoting()
        {
        }

        public static bool Insert(int detailId, int userId, int auditorRoleId, int classificationId) //INSERT [dbo].[FIDetail_Voting]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[FIDetail_Voting] " +
                           "([DetailId], [UserId], [AuditorRoleId], [ClassificationId], [IsCurrent], [InsDate]) VALUES " +
                           "(@detailId, @userId, @auditorRoleId, @classificationId, 'TRUE', getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@detailId", detailId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@auditorRoleId", auditorRoleId);
                cmd.Parameters.AddWithValue("@classificationId", classificationId);

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

        public static bool HasAlreadyVoted(int detailId, int userId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[FIDetail_Voting] " +
                              "WHERE DetailId = @detId AND UserId = @userId AND IsCurrent = 'True' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = true;
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

        public static DateTime? VotingDate_ifHasAlreadyVoted(int detailId, int userId)
        {
            DateTime? ret = null;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT InsDate FROM [dbo].[FIDetail_Voting] " +
                              "WHERE DetailId = @detId AND UserId = @userId AND IsCurrent = 'True' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToDateTime(reader["InsDate"].ToString()); ;
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

        public static List<FIDetailVoting> Select()
        {
            List<FIDetailVoting> ret = new List<FIDetailVoting>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DetailId], [UserId], [AuditorRoleId], [ClassificationId], isnull([IsCurrent], 'FALSE') as IsCurrent, [InsDate] " +
                              "FROM [dbo].[FIDetail_Voting] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new FIDetailVoting()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString())),
                        AuditorRole = new AuditorsRoles(Convert.ToInt32(reader["AuditorRoleId"].ToString())),
                        Classification = new Classification(Convert.ToInt32(reader["ClassificationId"].ToString())),
                        IsCurrent = Convert.ToBoolean(reader["IsCurrent"].ToString()),
                        InsDate = Convert.ToDateTime(reader["InsDate"].ToString())
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

        public static List<FIDetailVoting> SelectCurrent(int detailId)
        {
            List<FIDetailVoting> ret = new List<FIDetailVoting>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [DetailId], [UserId], [AuditorRoleId], [ClassificationId], isnull([IsCurrent], 'FALSE') as IsCurrent, [InsDate] " +
                              "FROM [dbo].[FIDetail_Voting] " +
                              "WHERE detailId = @detId AND isnull([IsCurrent], 'FALSE') = 'TRUE' ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new FIDetailVoting()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        DetailId = Convert.ToInt32(reader["DetailId"].ToString()),
                        User = new Users(Convert.ToInt32(reader["UserId"].ToString())),
                        AuditorRole = new AuditorsRoles(Convert.ToInt32(reader["AuditorRoleId"].ToString())),
                        Classification = new Classification(Convert.ToInt32(reader["ClassificationId"].ToString())),
                        IsCurrent = Convert.ToBoolean(reader["IsCurrent"].ToString()),
                        InsDate = Convert.ToDateTime(reader["InsDate"].ToString())
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

        public static int getMaxPackId(int detailId)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT max(isnull(PackId, 0)) as PackId " +
                              "FROM [dbo].[FIDetail_Voting] " +
                              "WHERE DetailId = @detId ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@detId", detailId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["PackId"].ToString());
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

        public static bool UpdatePackAndCurrentFlags(int detailId) //UPDATE [dbo].[FIDetail_Voting]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[FIDetail_Voting] " +
                           "SET PackId = @packId, IsCurrent = 'FALSE' " +
                           "WHERE detailId = @detailId AND isnull([IsCurrent], 'FALSE') = 'TRUE' ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@detailId", detailId);
                cmd.Parameters.AddWithValue("@packId", getMaxPackId(detailId) + 1);

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



        public static ChiefVoteCause doesChiefNeedsToVote(FICategory category, List<FIDetailVoting> votes)
        {
            ChiefVoteCause ret = ChiefVoteCause.None;

            List<int> decisions = new List<int>();
            foreach (FIDetailVoting vote in votes)
            {
                if (decisions.Exists(i => i == vote.Classification.Id) == false)
                {
                    decisions.Add(vote.Classification.Id);
                }
            }

            if (category.NeedsApproval == true) //1, 2
            {
                ret = ChiefVoteCause.High_Risk;
            }
            else if (decisions.Count > 1)
            {
                ret = ChiefVoteCause.Different_Decisions;
            }
            else if (category.NeedsApproval == false && decisions.Count == 1 && (decisions[0] == 2 || decisions[0] == 3)) //3, 4, 5
            {
                ret = ChiefVoteCause.Low_Risk_AltNo;
            }

            return ret;
        }

        public static bool IsUserApprover(int auditorRoleId, AuditOwners auditorOwners, int detailId, ChiefVoteCause voteCause)
        {
            bool ret = false;

            if (auditorRoleId == 1) //auditor1
            {
                if (auditorOwners.Auditor2.Id > 0)
                {
                    if (FIDetailVoting.HasAlreadyVoted(detailId, auditorOwners.Auditor2.Id) == false)
                    {
                        return ret;
                    }
                }

                if (auditorOwners.Supervisor.Id > 0)
                {
                    return ret;
                }

                if (voteCause != ChiefVoteCause.None) //cae an xreiazetai
                {
                    return ret;
                }

                //tote eimai autos poy tha parei tin apofasi
                ret = true;
            }
            //eimai o auditor2, gia na me afinei na psifisw: 
            //den exei psifisei akoma o supervisor an yparxei, oute o cae an xreiazetai
            else if (auditorRoleId == 2) //auditor2
            {
                if (auditorOwners.Auditor1.Id > 0)
                {
                    if (FIDetailVoting.HasAlreadyVoted(detailId, auditorOwners.Auditor1.Id) == false)
                    {
                        return ret;
                    }
                }

                if (auditorOwners.Supervisor.Id > 0)
                {
                    return ret;
                }

                if (voteCause != ChiefVoteCause.None) //cae an xreiazetai
                {
                    return ret;
                }

                //tote eimai autos poy tha parei tin apofasi
                ret = true;
            }
            //eimai o supervisor, gia na me afinei na psifisw: 
            //den exei psifisei akoma o cae an xreiazetai
            //oi auditor1,2 exoun psifisei
            else if (auditorRoleId == 3) //supervisor
            {
                if (voteCause != ChiefVoteCause.None) //cae an xreiazetai
                {
                    return ret;
                }

                //tote eimai autos poy tha parei tin apofasi
                ret = true;
            }
            //eimai o cae, gia na me afinei na psifisw: 
            //exoun psifisei oloi kai pairnw thn teliki apofasi
            else if (auditorRoleId == 4) //c.a.e.
            {
                //tote eimai autos poy tha parei tin apofasi
                ret = true;
            }

            return ret;
        }

    }

    public enum ChiefVoteCause
    {
        None,
        Different_Decisions,
        High_Risk,
        Low_Risk_AltNo
    }
}
