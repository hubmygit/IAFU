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

        private void MIfinalizeAudit_Click(object sender, EventArgs e)
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

        private void MIshowFindings_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == Id).First();

                if (UserAction.IsLegal(Action.Header_View)) 
                {
                    FIView frmFIView = new FIView(thisAudit);
                    frmFIView.ShowDialog();
                }
            }
        }

        private void btnCreateNewAudit_Click(object sender, EventArgs e)
        {
            if (UserAction.IsLegal(Action.Audit_Create))
            {
                AuditInsert frmInsertNewAudit = new AuditInsert();
                frmInsertNewAudit.ShowDialog();


                //refresh
                //int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                auditBList = Audit.Select(UserInfo.roleDetails.IsAdmin); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                //int rowHandle = gridView1.GetRowHandle(index);
                //gridView1.FocusedRowHandle = rowHandle;
            }



        }
    }
}
