using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class Notifications
    {

        public Notifications()
        {
        }

        public static void firstNotification()
        {
            int detailId = 0;
            int placeholderId = 0;
            //----------------------------------------------------

            //--M.T. / 1 φορά κάθε 1η / Όσα λήγουν στο μήνα αυτό
            //--*****Αν δεν έχει στείλει απάντηση *****
            //-------------------------------------------

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string SelectSt =
            "SELECT D.Id as DetailId, D.ActionDt, P.Id, P.PlaceholderId, U.Id, " +
            "       convert(varchar(500), decryptByPassPhrase(@passPhrase', U.FullName)) as FullName, " +
            "       convert(varchar(500), decryptByPassPhrase(@passPhrase, U.Email)) as Email " +
            "FROM [dbo].[Audit] A left outer join " +
            "     [dbo].[FIHeader] H on A.Id = H.AuditId left outer join " +
            "     [dbo].[FIDetail] D on H.Id = D.FIHeaderId left outer join " +
            "     [dbo].[FIDetail_Placeholders] P on D.Id = P.FIDetailId left outer join " +
            "     [dbo].[Owners_MT] O on O.PlaceholderId = P.PlaceholderId left outer join " +
            "     [dbo].[Users] U on U.Id = O.UserId " +
            "WHERE isnull(A.IsDeleted, 0) = 0 AND isnull(H.IsDeleted, 0) = 0 AND isnull(D.IsDeleted, 0) = 0 AND " +
            "     D.IsPublished = 1 AND isnull(D.IsFinalized,0) = 0 AND " +
            "     year(D.ActionDt) = year(getdate()) and month(D.ActionDt) = month(getdate()) AND O.IsCurrent = 1 " +
            "ORDER BY U.Id ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    detailId = Convert.ToInt32(reader["DetailId"].ToString());
                    placeholderId = Convert.ToInt32(reader["PlaceholderId"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);

                //Log file...
            }

            //export a list 
            //----------------------------------------------------

            ActionSide actSide = FIDetailActivity.getActionSide_forAuditees(detailId, placeholderId);

            if (actSide.Id == 2) //auditees
            {
                //add to a list to group emails by user/ or send one for each detail

                //and send emails
            }
        }
        
    }
}
