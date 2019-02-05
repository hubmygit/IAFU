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
                           "([DetailId], [UserId], [AuditorRoleId] [ClassificationId], [IsCurrent], [InsDate]) VALUES " +
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
    }
}
