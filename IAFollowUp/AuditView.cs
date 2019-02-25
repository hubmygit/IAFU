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

            auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin);

            gridControl1.DataSource = auditBList;
            
            gridView1.Columns["IsDeleted"].Visible = UserInfo.roleDetails.IsAdmin;
        }

        public BindingList<Audit> auditBList = new BindingList<Audit>();

        
        private void MIupdate_Click(object sender, EventArgs e)
        {
            // Update
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0) 
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();

                //Έτσι κι αλλιώς δε βλέπω Deleted ως εδώ
                //if (thisAudit.IsDeleted)
                //{
                //    MessageBox.Show("The audit has been deleted!");
                //    return;
                //}

                //if (!UserAction.IsLegal(Action.Audit_Edit, thisAudit.Auditor1.Id, thisAudit.Auditor2.Id, thisAudit.Supervisor.Id))
                if (!UserAction.IsLegal(Action.Audit_Edit, thisAudit))
                {
                    return;
                }

                //if (thisAudit.IsCompleted == true)
                //{
                //    MessageBox.Show("The audit has been finalized!"); //check if published too...
                //    return;
                //}
                
                AuditInsert frmUpdateAudit = new AuditInsert(thisAudit);
                frmUpdateAudit.ShowDialog();

                if (frmUpdateAudit.success)
                {
                    //int gridTopRowIndex = gridView1.TopRowIndex; //a (this way does not select the line that was focused before update)
                    int index1 = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle); //b

                    //refresh
                    auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                    gridControl1.DataSource = auditBList; //DataSource

                    //gridView1.TopRowIndex = gridTopRowIndex; //a

                    int rowHandle1 = gridView1.GetRowHandle(index1); //b
                    gridView1.FocusedRowHandle = rowHandle1; //b
                }
            }
        }

        private void MIdelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                //if (thisAudit.IsDeleted)
                //{
                //    MessageBox.Show("The audit has already been deleted!");
                //    return;
                //}

                if (!UserAction.IsLegal(Action.Audit_Delete, thisAudit))
                {
                    return;
                }

                //if (thisAudit.IsCompleted == true)
                //{
                //    MessageBox.Show("The audit has been finalized!"); //check if published too...
                //    return;
                //}

                //check references of header/detail?? or only published/finalized??

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "Audit Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (Audit.Delete(AuditId))
                    {
                        ChangeLog.Insert(new Audit() { Id = AuditId, IsDeleted = false }, new Audit() { Id = AuditId, IsDeleted = true }, "Audit");

                        MessageBox.Show("The Deletion was successful!");

                        //refresh
                        auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
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

                AuditAttachments attachedFiles = new AuditAttachments(Id);

                //if (thisAudit.IsCompleted == true || thisAudit.IsDeleted == true)
                //{
                //    attachedFiles.makeReadOnly();
                //}

                if (!UserAction.IsLegal(Action.Audit_Attach, thisAudit))
                {
                    attachedFiles.makeReadOnly();
                }

                attachedFiles.ShowDialog();

                if (attachedFiles.success)
                {
                    //refresh
                    int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                    auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                    gridControl1.DataSource = auditBList; //DataSource
                    int rowHandle = gridView1.GetRowHandle(index);
                    gridView1.FocusedRowHandle = rowHandle;
                }

            }
        }

        /*private void MIfinalizeAudit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();
                
                //if (thisAudit.IsDeleted == true)
                //{
                //    MessageBox.Show("The audit has been deleted!");
                //    return;
                //}

                //if (thisAudit.IsCompleted == true)
                //{
                //    MessageBox.Show("The audit has already been completed!");
                //    return;
                //}

                if (!UserAction.IsLegal(Action.Audit_Finalize, thisAudit))
                {
                    return;
                }

                if (Audit.UpdateCompleted(thisAudit.Id))
                {
                    ChangeLog.Insert(new Audit() { Id = thisAudit.Id, IsCompleted = false }, new Audit() { Id = thisAudit.Id, IsCompleted = true }, "Audit");

                    MessageBox.Show("The Update was successful!");

                    //refresh
                    int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                    auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                    gridControl1.DataSource = auditBList; //DataSource
                    int rowHandle = gridView1.GetRowHandle(index);
                    gridView1.FocusedRowHandle = rowHandle;
                }
                else
                {
                    MessageBox.Show("The Update was not successful!");
                }

            }
        }
        */

        private void MIfinalizeAudit_Click(object sender, EventArgs e)
        {
            //finalize and Publish & Send email & Update audit.protocol !!! closure->finalized
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                if (!UserAction.IsLegal(Action.Audit_Finalize, thisAudit))
                {
                    return;
                }
                
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to finalize this audit and publish all details?", "Finalize and Publish", MessageBoxButtons.YesNo);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                //STEP 1 ->********** give real protocol nums **********
                MessageBox.Show("Before publication please check if Protocol Numbers and Report Date are correct or give the final values on the following form!");
                AuditProtocolNums frmAuditProtocolNums = new AuditProtocolNums(thisAudit);
                frmAuditProtocolNums.ShowDialog();
                if (!frmAuditProtocolNums.success)
                {
                    return;
                }
                //STEP 1 <-********** give real protocol nums **********

                //STEP 2 ->********** update audit finalization flag **********
                if (!Audit.UpdateCompleted(thisAudit.Id))
                {
                    return;
                }
                else
                {
                    ChangeLog.Insert(new Audit() { Id = thisAudit.Id, IsCompleted = false }, new Audit() { Id = thisAudit.Id, IsCompleted = true }, "Audit");
                }
                //STEP 2 <-********** update audit finalization flag **********

                //STEP 3 ->********** publish details - update flags **********
                int detailsToPublishCnt = 0;
                if (thisAudit.FIHeaders.Exists(i => i.IsDeleted == false))
                {
                    List<FIHeader> headersToPub = thisAudit.FIHeaders.Where(i => i.IsDeleted == false).ToList();
                    foreach (FIHeader headToPub in headersToPub)
                    {
                        detailsToPublishCnt += headToPub.FIDetails.Count(i => i.IsDeleted == false);
                    }
                }
                List<FIDetail> detailsPublished = FIDetail.PublishAll(thisAudit);
                int detailsPublishedCnt = detailsPublished.Count;
                if (detailsPublishedCnt <= 0)
                {
                    //refresh if finalized
                    auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                    gridControl1.DataSource = auditBList; //DataSource
                    gridView1.FocusedRowHandle = rowHandle;

                    return;
                }
                else
                {
                    MessageBox.Show(detailsPublishedCnt.ToString() + " out of " + detailsToPublishCnt.ToString() + " Details Published!");
                }
                //STEP 3 <-********** publish details - update flags **********

                //STEP 4 <-********** closure flag --> auto finalized **********
                int closedDetailsToFinalizeCnt = detailsPublished.Count(i => i.IsClosed);
                if (closedDetailsToFinalizeCnt > 0)
                {
                    int closedDetailsFinalizedCnt = FIDetail.FinalizeClosed(detailsPublished.Where(i => i.IsClosed).ToList());
                    MessageBox.Show(closedDetailsFinalizedCnt.ToString() + " out of " + closedDetailsToFinalizeCnt.ToString() + " Closed Details Finalized!");
                }
                //STEP 4 <-********** closure flag --> auto finalized **********

                //STEP 5 ->********** send email **********
                List<FIDetail> detailsToSendEmail = detailsPublished.Where(i => i.IsClosed == false).ToList();

                if (detailsToSendEmail.Count > 0) //(detailsPublished - Closed) > 0 then send email
                {
                    EmailProperties emailProp = new EmailProperties();
                    //emailProp.Subject = "ΕΣΩΤΕΡΙΚΟΣ ΕΛΕΓΧΟΣ: " + thisAudit.Title;
                    //emailProp.Body = "Σας ενημερώνουμε ότι έχουν καταχωρηθεί στην εφαρμογή του Εσωτερικού Ελέγχου ευρήματα / ενέργειες της περιοχής ευθύνης σας. Παρακαλούμε για τις ενέργειές σας.";
                    ActivityDescription actDescr = new ActivityDescription(1);
                    emailProp.Subject = actDescr.EmailSubject;
                    emailProp.Body = actDescr.EmailBody.Replace("@", thisAudit.Title);

                    List<Recipient> distinctRecipients = new List<Recipient>();
                    foreach (FIDetail det in detailsToSendEmail)
                    {
                        List<Users> usersList = new List<Users>();
                        foreach (Placeholders ph in det.Placeholders)
                        {
                            usersList.Add(Owners_MT.GetCurrentOwnerMT(ph.Id).User);
                        }

                        //foreach (Users usr in det.Owners)
                        foreach (Users usr in usersList)
                        {
                            Recipient thisRecipient = new Recipient() { FullName = usr.FullName, Email = usr.getEmail() };
                            if (distinctRecipients.Exists(i => i.Email == thisRecipient.Email) == false || distinctRecipients.Exists(i => i.FullName == thisRecipient.FullName) == false)
                            {
                                distinctRecipients.Add(thisRecipient);
                            }
                        }
                    }
                    emailProp.Recipients = distinctRecipients;
                    EmailToSend frmSendEmailToAuditees = new EmailToSend(emailProp);
                    frmSendEmailToAuditees.ShowDialog();
                }
                //STEP 5 <-********** send email **********

                //refresh
                auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void MIshowFindings_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                if (UserAction.IsLegal(Action.Header_View)) 
                {                   
                    FIView frmFIView = new FIView(thisAudit);
                    frmFIView.ShowDialog();

                    //refresh
                    auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                    gridControl1.DataSource = auditBList; //DataSource
                    gridView1.FocusedRowHandle = rowHandle;
                }
            }
        }

        private void btnCreateNewAudit_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Audit_Create))
            {
                AuditInsert frmInsertNewAudit = new AuditInsert();
                frmInsertNewAudit.ShowDialog();

                if (frmInsertNewAudit.success)
                {
                    Audit justInsertedAudit = new Audit(true, frmInsertNewAudit.newAuditRecord.Id);
                    FIView frmFIView = new FIView(justInsertedAudit);
                    frmFIView.ShowDialog();
                }

                //refresh
                //int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                //int rowHandle = gridView1.GetRowHandle(index);
                //gridView1.FocusedRowHandle = rowHandle;
            }



        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(sfd.FileName);
            }
        }
    }
}
