using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
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

        public FIDetail(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT D.[Id], D.[FIHeaderId], " +
                              "CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , D.[Description])) as Description, " +
                              "D.ActionDt, " +
                              "CONVERT(varchar(7800), DECRYPTBYPASSPHRASE( @passPhrase , D.[ActionReq])) as ActionReq,  " +
                              "D.ActionCode, isnull(D.[IsClosed], 'FALSE') as IsClosed, isnull(D.[IsPublished], 'FALSE') as IsPublished, isnull(D.[IsFinalized], 'FALSE') as IsFinalized, " +
                              "isnull(D.[IsDeleted], 'FALSE') as IsDeleted, D.[FISubId] " +
                              "FROM [dbo].[FIDetail] D " +
                              "WHERE D.[Id] = @detId ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@passPhrase", SqlDBInfo.passPhrase);

                cmd.Parameters.AddWithValue("@detId", givenId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime? DetailActionDt;

                    if (reader["ActionDt"] == System.DBNull.Value)
                    {
                        DetailActionDt = null;
                    }
                    else
                    {
                        DetailActionDt = Convert.ToDateTime(reader["ActionDt"].ToString());
                    }

                    Id = Convert.ToInt32(reader["Id"].ToString());
                    FIHeaderId = Convert.ToInt32(reader["FIHeaderId"].ToString());
                    Description = reader["Description"].ToString();
                    ActionDt = DetailActionDt;
                    ActionReq = reader["ActionReq"].ToString();
                    ActionCode = reader["ActionCode"].ToString();
                    IsClosed = Convert.ToBoolean(reader["IsClosed"].ToString());
                    IsPublished = Convert.ToBoolean(reader["IsPublished"].ToString());
                    IsFinalized = Convert.ToBoolean(reader["IsFinalized"].ToString());
                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString());
                    //Owners = FIDetail.getOwners(Convert.ToInt32(reader["Id"].ToString()))
                    Placeholders = FIDetail.getOwners(Convert.ToInt32(reader["Id"].ToString()));
                    FISubId = reader["FISubId"].ToString();

                    if (Placeholders.Count >= 1 && Placeholders[0] != null)
                    {
                        CurrentOwner1 = Owners_MT.GetCurrentOwnerMT(Placeholders[0].Id);
                    }
                    if (Placeholders.Count >= 2 && Placeholders[1] != null)
                    {
                        CurrentOwner2 = Owners_MT.GetCurrentOwnerMT(Placeholders[1].Id);
                    }
                    if (Placeholders.Count >= 3 && Placeholders[2] != null)
                    {
                        CurrentOwner3 = Owners_MT.GetCurrentOwnerMT(Placeholders[2].Id);
                    }
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("FIDetail - The following error occurred: " + ex.Message, true);
            }
        }

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
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("FIDetail.getOwners - The following error occurred: " + ex.Message, true);
            }

            return ret;
        }


    }
}
