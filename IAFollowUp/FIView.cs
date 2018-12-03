﻿using System;
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

            gridControl1.DataSource = new BindingList<Audit>() { givenAudit };
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
        }

        private void btnUpdateHeader_Click(object sender, EventArgs e)
        {
            //User Actions...


            // Update
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                FIHeader firstHeader = thisAudit.FIHeaders[0];

                FIHeaderInsert fiHeaderUpdate = new FIHeaderInsert(thisAudit, firstHeader);
                fiHeaderUpdate.ShowDialog();
                
                //refresh
                //...
            }
        }

        private void btnDeleteHeader_Click(object sender, EventArgs e)
        {
            //User Actions...


            //Delete
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                FIHeader firstHeader = thisAudit.FIHeaders[0];

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this record?", "F/I Header Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (FIHeader.Delete(firstHeader.Id))
                    {
                        ChangeLog.Insert(new FIHeader() { Id = firstHeader.Id, IsDeleted = false }, new FIHeader() { Id = firstHeader.Id, IsDeleted = true }, "FIHeader");

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
