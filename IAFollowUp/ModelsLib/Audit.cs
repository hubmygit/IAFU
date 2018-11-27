using System;
using System.Collections.Generic;
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


    }
}
