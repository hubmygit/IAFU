using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class FIView : Form
    {
        public FIView()
        {
            InitializeComponent();
        }

        public FIView(Audit givenAudit)
        {
            InitializeComponent();

            thisAudit = givenAudit;

            txtCompany.Text = thisAudit.Company.Name;
            txtYear.Text = thisAudit.Year.ToString();
            txtAuditTitle.Text = thisAudit.Title;

            gridControlHeaders.DataSource = new BindingList<FIHeader>(thisAudit.FIHeaders);

            gridViewHeaders.Columns["IsDeleted"].Visible = UserInfo.roleDetails.IsAdmin;
            gridViewDetails.Columns["IsDeleted"].Visible = UserInfo.roleDetails.IsAdmin;
        }

        Audit thisAudit = new Audit();

        private void btnCreateNewHeader_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Header_Create, thisAudit))
            {
                FIHeaderInsert frmFIHeaderIns = new FIHeaderInsert(thisAudit);
                frmFIHeaderIns.ShowDialog();

                //refresh
                AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                thisAudit.FIHeaders = Audit.getFIHeaders(thisAudit.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                gridControlHeaders.DataSource = new BindingList<FIHeader>(thisAudit.FIHeaders); //DataSource
            }          
        }

        private void MIeditHeader_Click(object sender, EventArgs e)
        {
            // Update
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();

                if (!UserAction.IsLegal(Action.Header_Edit, thisAudit))//, selHeader))
                {
                    return;
                }

                FIHeaderInsert fiHeaderUpdate = new FIHeaderInsert(thisAudit, selHeader);
                fiHeaderUpdate.ShowDialog();

                if (fiHeaderUpdate.success)
                {
                    int index1 = gridViewHeaders.GetDataSourceRowIndex(gridViewHeaders.FocusedRowHandle);

                    //refresh
                    AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                    thisAudit.FIHeaders = Audit.getFIHeaders(thisAudit.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                    gridControlHeaders.DataSource = new BindingList<FIHeader>(thisAudit.FIHeaders); //DataSource
                 
                    int rowHandle1 = gridViewHeaders.GetRowHandle(index1);
                    gridViewHeaders.FocusedRowHandle = rowHandle1;
                }
            }
        }

        private void MIdeleteHeader_Click(object sender, EventArgs e)
        {
            //Delete
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();

                if (!UserAction.IsLegal(Action.Header_Delete, thisAudit, selHeader))
                {
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "F/I Header Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (FIHeader.Delete(selHeader.Id))
                    {
                        ChangeLog.Insert(new FIHeader() { Id = selHeader.Id, IsDeleted = false }, new FIHeader() { Id = selHeader.Id, IsDeleted = true }, "FIHeader");

                        MessageBox.Show("The Deletion was successful!");
                        
                        //refresh
                        int index1 = gridViewHeaders.GetDataSourceRowIndex(gridViewHeaders.FocusedRowHandle);

                        AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                        thisAudit.FIHeaders = Audit.getFIHeaders(thisAudit.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                        gridControlHeaders.DataSource = new BindingList<FIHeader>(thisAudit.FIHeaders); //DataSource

                        int rowHandle1 = gridViewHeaders.GetRowHandle(index1);
                        gridViewHeaders.FocusedRowHandle = rowHandle1;
                    }
                    else
                    {
                        MessageBox.Show("The Deletion was not successful!");
                    }
                }
            }
        }

        private void btnCreateNewDetail_Click(object sender, EventArgs e)
        {
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();

                if (UserAction.IsLegal(Action.Detail_Create, thisAudit)) //, selHeader))
                {
                    FIDetailInsert frmFIDetailIns = new FIDetailInsert(thisAudit, selHeader);
                    frmFIDetailIns.ShowDialog();

                    //refresh
                    int index1 = gridViewDetails.GetDataSourceRowIndex(gridViewDetails.FocusedRowHandle);
                    AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                    thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails = Audit.getFIDetails(selHeader.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                    gridControlDetails.DataSource = new BindingList<FIDetail>(selHeader.FIDetails);
                    //gridControlDetails.DataSource = new BindingList<FIDetail>(thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails); //DataSource
                    int rowHandle1 = gridViewDetails.GetRowHandle(index1);
                    gridViewDetails.FocusedRowHandle = rowHandle1;
                }
            }
            else
            {
                MessageBox.Show("Please select a Header first!");
            }
        }


        private void gridViewHeaders_MouseDown(object sender, MouseEventArgs e)
        {
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                List<FIDetail> RefDetails = thisAudit.FIHeaders.Where(i => i.Id == Id).First().FIDetails;

                if (UserAction.IsLegal(Action.Detail_View))
                {
                    gridControlDetails.DataSource = new BindingList<FIDetail>(RefDetails);
                }
            }
        }

        private void MIeditDetail_Click(object sender, EventArgs e)
        {
            // Update
            if (gridViewDetails.SelectedRowsCount > 0 && gridViewDetails.GetSelectedRows()[0] >= 0)
            {
                int headerId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["FIHeaderId"]).ToString());
                int detailId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == headerId).First();
                FIDetail selDetail = selHeader.FIDetails.Where(k => k.Id == detailId).First();

                if (!UserAction.IsLegal(Action.Detail_Edit, thisAudit)) //, selHeader, selDetail))
                {
                    return;
                }

                FIDetailInsert fiDetailUpdate = new FIDetailInsert(thisAudit, selHeader, selDetail);
                fiDetailUpdate.ShowDialog();

                if (fiDetailUpdate.success)
                {
                    //refresh
                    int index1 = gridViewDetails.GetDataSourceRowIndex(gridViewDetails.FocusedRowHandle);
                    AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                    thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails = Audit.getFIDetails(selHeader.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                    gridControlDetails.DataSource = new BindingList<FIDetail>(thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails); //DataSource

                    int rowHandle1 = gridViewDetails.GetRowHandle(index1);
                    gridViewDetails.FocusedRowHandle = rowHandle1;
                }
            }
        }

        private void MIdeleteDetail_Click(object sender, EventArgs e)
        {
            //Delete
            if (gridViewDetails.SelectedRowsCount > 0 && gridViewDetails.GetSelectedRows()[0] >= 0)
            {
                int headerId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["FIHeaderId"]).ToString());
                int detailId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == headerId).First();
                FIDetail selDetail = selHeader.FIDetails.Where(k => k.Id == detailId).First();

                if (!UserAction.IsLegal(Action.Detail_Delete, thisAudit, selHeader, selDetail))
                {
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "F/I Detail Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (FIDetail.Delete(selDetail.Id))
                    {
                        ChangeLog.Insert(new FIDetail() { Id = selDetail.Id, IsDeleted = false }, new FIDetail() { Id = selDetail.Id, IsDeleted = true }, "FIDetail");

                        MessageBox.Show("The Deletion was successful!");

                        //refresh
                        int index1 = gridViewDetails.GetDataSourceRowIndex(gridViewDetails.FocusedRowHandle);
                        AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                        thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails = Audit.getFIDetails(selHeader.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                        gridControlDetails.DataSource = new BindingList<FIDetail>(thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails); //DataSource

                        int rowHandle1 = gridViewDetails.GetRowHandle(index1);
                        gridViewDetails.FocusedRowHandle = rowHandle1;
                    }
                    else
                    {
                        MessageBox.Show("The Deletion was not successful!");
                    }
                }
            }

        }

        private void btnPublishDetails_Click(object sender, EventArgs e)
        {
            //Publish & Send email & Update audit.protocol !!! closure->finalized
            //if (gridViewDetails.SelectedRowsCount > 0 && gridViewDetails.GetSelectedRows()[0] >= 0 && gridViewDetails.RowCount > 0)

            if (!UserAction.IsLegal(Action.Detail_Publish, thisAudit)) //, selHeader))
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to publish all details of all headers?", "F/I Details Publication", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //STEP 1 ->********** give real protocol nums **********
                MessageBox.Show("Before publication please check if protocol numbers are correct or give the final values on the following form!");
                AuditProtocolNums frmAuditProtocolNums = new AuditProtocolNums(thisAudit);
                frmAuditProtocolNums.ShowDialog();
                if (!frmAuditProtocolNums.success)
                {
                    return;
                }
                //STEP 1 <-********** give real protocol nums **********

                //STEP 2 ->********** publish - update flags **********
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
                MessageBox.Show(detailsPublishedCnt.ToString() + " out of " + detailsToPublishCnt.ToString() + " Details Published!");
                if (detailsPublishedCnt <= 0)
                {
                    return;
                }
                //STEP 2 <-********** publish - update flags **********

                //STEP 3 ->********** closure flag --> auto finalized **********
                int closedDetailsToFinalizeCnt = detailsPublished.Count(i => i.IsClosed);
                if (closedDetailsToFinalizeCnt > 0)
                {
                    int closedDetailsFinalizedCnt = FIDetail.FinalizeClosed(detailsPublished.Where(i => i.IsClosed).ToList());
                    MessageBox.Show(closedDetailsFinalizedCnt.ToString() + " out of " + closedDetailsToFinalizeCnt.ToString() + " Closed Details Finalized!");
                }
                //STEP 3 <-********** closure flag --> auto finalized **********

                //STEP 4 ->********** send email **********
                List<FIDetail> detailsToSendEmail = detailsPublished.Where(i => i.IsClosed == false).ToList();

                if (detailsToSendEmail.Count > 0) //(detailsPublished - Closed) > 0 then send email
                {
                    EmailProperties emailProp = new EmailProperties();
                    emailProp.Subject = "ΕΣΩΤΕΡΙΚΟΣ ΕΛΕΓΧΟΣ: " + thisAudit.Title;
                    emailProp.Body = "Σας ενημερώνουμε ότι έχουν καταχωρηθεί στην εφαρμογή του Εσωτερικού Ελέγχου ευρήματα / ενέργειες της περιοχής ευθύνης σας. Παρακαλούμε για τις ενέργειές σας.";
                    List<Recipient> distinctRecipients = new List<Recipient>();
                    foreach (FIDetail det in detailsToSendEmail)
                    {
                        foreach (Users usr in det.Owners)
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
                //STEP 4 <-********** send email **********

                //->********** refresh **********
                MessageBox.Show("ToDo: Refresh Grids...");
                /*
                //selected row sta details-to focus efyge apo to header!!!!!! ---oxi---
                //int zzHeaderId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["FIHeaderId"]).ToString());
                //int zzHeaderRowHandle = gridViewHeaders.GetRowHandle(thisAudit.FIHeaders.FindIndex(i => i.Id == zzHeaderId));
                //int zzHeaderIndex = gridViewHeaders.GetDataSourceRowIndex(zzHeaderRowHandle);

                //check an kanei publish kai den exei kanei klik pouthena px den exei katholou details fortomena!!!!!!
                //----------------------------
                int HeaderIndex = gridViewHeaders.GetDataSourceRowIndex(gridViewHeaders.FocusedRowHandle);
                int DetailIndex = gridViewDetails.GetDataSourceRowIndex(gridViewDetails.FocusedRowHandle);
                AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();
                
                thisAudit.FIHeaders = Audit.getFIHeaders(thisAudit.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //refresh headers/details
                gridControlHeaders.DataSource = new BindingList<FIHeader>(thisAudit.FIHeaders); //DataSource
                //IndexOf de douleuei me to object mou...na allaksei
                gridControlDetails.DataSource = new BindingList<FIDetail>(thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails); //DataSource
                int HeaderRowHandle = gridViewHeaders.GetRowHandle(HeaderIndex);
                int DetailRowHandle = gridViewDetails.GetRowHandle(DetailIndex);
                gridViewHeaders.FocusedRowHandle = HeaderRowHandle;
                gridViewDetails.FocusedRowHandle = DetailRowHandle;
                */
                //<-********** refresh **********
            }

        }

        private void mIfinalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Finalize
            if (gridViewDetails.SelectedRowsCount > 0 && gridViewDetails.GetSelectedRows()[0] >= 0)
            {
                int headerId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["FIHeaderId"]).ToString());
                int detailId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == headerId).First();
                FIDetail selDetail = selHeader.FIDetails.Where(k => k.Id == detailId).First();

                if (!UserAction.IsLegal(Action.Detail_Finalize, thisAudit)) //, selHeader, selDetail))
                {
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to finalize this record?", "F/I Detail Finalization", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (FIDetail.Finalize(selDetail.Id))
                    {
                        ChangeLog.Insert(new FIDetail() { Id = selDetail.Id, IsFinalized = selDetail.IsFinalized }, new FIDetail() { Id = selDetail.Id, IsFinalized = true }, "FIDetail");

                        MessageBox.Show("The Finalization was successful!");

                        //refresh
                        int index1 = gridViewDetails.GetDataSourceRowIndex(gridViewDetails.FocusedRowHandle);
                        AuditOwners auditOwners = new AuditOwners(thisAudit.Auditor1, thisAudit.Auditor2, thisAudit.Supervisor);
                        thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails = Audit.getFIDetails(selHeader.Id, UserInfo.roleDetails.IsAdmin, auditOwners); //List -> (BindingList)
                        gridControlDetails.DataSource = new BindingList<FIDetail>(thisAudit.FIHeaders[thisAudit.FIHeaders.IndexOf(selHeader)].FIDetails); //DataSource

                        int rowHandle1 = gridViewDetails.GetRowHandle(index1);
                        gridViewDetails.FocusedRowHandle = rowHandle1;
                    }
                    else
                    {
                        MessageBox.Show("The Finalization was not successful!");
                    }
                }



            }

        }
    }
}
