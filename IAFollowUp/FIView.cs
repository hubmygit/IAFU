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
        }

        Audit thisAudit = new Audit();

        private void btnCreateNewHeader_Click(object sender, EventArgs e)
        {
            //if (!UserAction.IsLegal(Action.Header_Create, glAudit.Auditor1ID, glAudit.Auditor2ID, glAudit.SupervisorID))
            //{
            //    return;
            //}

            FIHeaderInsert frmFIHeaderIns = new FIHeaderInsert(thisAudit);
            frmFIHeaderIns.ShowDialog();


            
            //refresh
            //auditBList = SelectAudit(); //BindingList
            //gridControl1.DataSource = auditBList; //DataSource
        }

        private void MIeditHeader_Click(object sender, EventArgs e)
        {
            //User Actions...


            // Update
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();

                FIHeaderInsert fiHeaderUpdate = new FIHeaderInsert(thisAudit, selHeader);
                fiHeaderUpdate.ShowDialog();

                //refresh
                //...
            }
        }

        private void MIdeleteHeader_Click(object sender, EventArgs e)
        {
            //User Actions...


            //Delete
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "F/I Header Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (FIHeader.Delete(selHeader.Id))
                    {
                        ChangeLog.Insert(new FIHeader() { Id = selHeader.Id, IsDeleted = false }, new FIHeader() { Id = selHeader.Id, IsDeleted = true }, "FIHeader");

                        MessageBox.Show("The Deletion was successful!");

                        //refresh
                        //...
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
            //User Actions...

            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == Id).First();

                FIDetailInsert frmFIDetailIns = new FIDetailInsert(thisAudit, selHeader); 
                frmFIDetailIns.ShowDialog();
            }

            //Refresh...
        }


        private void gridViewHeaders_MouseDown(object sender, MouseEventArgs e)
        {
            if (gridViewHeaders.SelectedRowsCount > 0 && gridViewHeaders.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridViewHeaders.GetRowCellValue(gridViewHeaders.GetSelectedRows()[0], gridViewHeaders.Columns["Id"]).ToString());
                List<FIDetail> RefDetails = thisAudit.FIHeaders.Where(i => i.Id == Id).First().FIDetails;

                gridControlDetails.DataSource = new BindingList<FIDetail>(RefDetails);
            }
        }

        private void MIeditDetail_Click(object sender, EventArgs e)
        {
            //User Actions...


            // Update
            if (gridViewDetails.SelectedRowsCount > 0 && gridViewDetails.GetSelectedRows()[0] >= 0)
            {
                int headerId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["FIHeaderId"]).ToString());
                int detailId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == headerId).First();
                FIDetail selDetail = selHeader.FIDetails.Where(k => k.Id == detailId).First();

                FIDetailInsert fiDetailUpdate = new FIDetailInsert(thisAudit, selHeader, selDetail);
                fiDetailUpdate.ShowDialog();

                //refresh
                //...
            }
        }

        private void MIdeleteDetail_Click(object sender, EventArgs e)
        {
            //User Actions...


            //Delete
            if (gridViewDetails.SelectedRowsCount > 0 && gridViewDetails.GetSelectedRows()[0] >= 0)
            {
                int headerId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["FIHeaderId"]).ToString());
                int detailId = Convert.ToInt32(gridViewDetails.GetRowCellValue(gridViewDetails.GetSelectedRows()[0], gridViewDetails.Columns["Id"]).ToString());
                FIHeader selHeader = thisAudit.FIHeaders.Where(i => i.Id == headerId).First();
                FIDetail selDetail = selHeader.FIDetails.Where(k => k.Id == detailId).First();

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "F/I Detail Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (FIDetail.Delete(selDetail.Id))
                    {
                        ChangeLog.Insert(new FIDetail() { Id = selDetail.Id, IsDeleted = false }, new FIDetail() { Id = selDetail.Id, IsDeleted = true }, "FIDetail");

                        MessageBox.Show("The Deletion was successful!");

                        //refresh
                        //...
                    }
                    else
                    {
                        MessageBox.Show("The Deletion was not successful!");
                    }
                }
            }

        }
    }
}
