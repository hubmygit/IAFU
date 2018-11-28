using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class AuditView : Form
    {
        public AuditView()
        {
            InitializeComponent();

            auditBList = SelectAudit();

            gridControl1.DataSource = auditBList;
        }

        public BindingList<Audit> auditBList = new BindingList<Audit>();

        public BindingList<Audit> SelectAudit()
        {
            BindingList<Audit> ret = new BindingList<Audit>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Year], [CompanyId], [AuditTypeId], " +
                              "CONVERT(varchar(500), DECRYPTBYPASSPHRASE( @passPhrase , [Title])) as Title, " +
                              "[ReportDt], " +
                              "[Auditor1Id], [Auditor2Id], [SupervisorId], " +
                              "[IsCompleted], [AuditNumber], [IASentNumber], " +
                              //"(SELECT count(*) FROM [dbo].[Audit_Attachments] T WHERE a.id = T.AuditID and A.RevNo = T.RevNo) as AttCnt, " +
                              "[AuditRatingId], isnull([IsDeleted], 'FALSE') as IsDeleted " +
                              "FROM [dbo].[Audit] A " +
                              "ORDER BY Id "; //ToDo

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
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString())
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

        private void MIupdate_Click(object sender, EventArgs e)
        {
            // Update
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0) 
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();

                if (thisAudit.IsDeleted)
                {
                    MessageBox.Show("The audit has been deleted!");
                    return;
                }

                if (!UserAction.IsLegal(Action.Audit_Edit, thisAudit.Auditor1.Id, thisAudit.Auditor2.Id, thisAudit.Supervisor.Id))
                {
                    return;
                }

                AuditInsert frmUpdateAudit = new AuditInsert(thisAudit);
                frmUpdateAudit.ShowDialog();

                if (frmUpdateAudit.success)
                {
                    //refresh
                    auditBList = SelectAudit(); //BindingList
                    gridControl1.DataSource = auditBList; //DataSource
                }
            }
        }

        private void MIdelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                if (thisAudit.IsDeleted)
                {
                    MessageBox.Show("The audit has already been deleted!");
                    return;
                }

                if (!UserAction.IsLegal(Action.Audit_Delete, thisAudit.Auditor1.Id, thisAudit.Auditor2.Id, thisAudit.Supervisor.Id))
                {
                    return;
                }

                //check references. ToDo...............................................................................

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "Audit Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (Audit.Delete(AuditId))
                    {
                        ChangeLog.Insert(new Audit() { Id = AuditId, IsDeleted = false }, new Audit() { Id = AuditId, IsDeleted = true }, "Audit");

                        MessageBox.Show("The Deletion was successful!");

                        //refresh
                        auditBList = SelectAudit(); //BindingList
                        gridControl1.DataSource = auditBList; //DataSource
                    }
                    else
                    {
                        MessageBox.Show("The Deletion was not successful!");
                    }
                }


            }
        }

        private void MIattachments_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();

                if (!UserAction.IsLegal(Action.Audit_Attach, thisAudit.Auditor1.Id, thisAudit.Auditor2.Id, thisAudit.Supervisor.Id))
                {
                    return;
                }

                AuditAttachments attachedFiles = new AuditAttachments(Id);
            }
        }
    }
}
