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
    public partial class ChangeAuditAuditors : Form
    {
        public ChangeAuditAuditors()
        {
            InitializeComponent();

            auditBList = Audit.SelectPending_ToChangeAuditors();
            gridControl1.DataSource = auditBList;
        }

        BindingList<Audit> auditBList = new BindingList<Audit>();

        private void MIaddOwner_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                if (thisAudit.Auditor1.Id > 0 && thisAudit.Auditor2.Id > 0)
                {
                    MessageBox.Show("There is no empty position to add an auditor!");
                    return;
                }

                UserSelector frmUserSel = new UserSelector(Users.getAuditors());
                if (frmUserSel.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                //check if already exists...
                if (thisAudit.Auditor1.Id == frmUserSel.usr.Id || thisAudit.Auditor2.Id == frmUserSel.usr.Id || thisAudit.Supervisor.Id == frmUserSel.usr.Id)
                {
                    MessageBox.Show("This Auditor already exists!");
                    return;
                }

                Users newUser = frmUserSel.usr;

                if (thisAudit.Auditor1.Id <= 0) //almost never...
                {
                    if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor1, newUser.Id))
                    {
                        ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor1 }, new Audit() { Id = thisAudit.Id, Auditor1 = newUser }, "Audit");
                        MessageBox.Show("Auditors changes on Audit was successful!");
                    }
                }
                else if (thisAudit.Auditor2.Id <= 0)
                {
                    if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor2, newUser.Id))
                    {
                        ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor2 = thisAudit.Auditor2 }, new Audit() { Id = thisAudit.Id, Auditor2 = newUser }, "Audit");
                        MessageBox.Show("Auditors changes on Audit was successful!");
                    }
                }
                
                //refresh
                auditBList = Audit.SelectPending_ToChangeAuditors(); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void MIaddSupervisor_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                if (thisAudit.Supervisor.Id > 0)
                {
                    MessageBox.Show("There is no empty position to add a supervisor!");
                }

                UserSelector frmUserSel = new UserSelector(Users.getAuditors());
                if (frmUserSel.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                //check if already exists...
                if (thisAudit.Auditor1.Id == frmUserSel.usr.Id || thisAudit.Auditor2.Id == frmUserSel.usr.Id || thisAudit.Supervisor.Id == frmUserSel.usr.Id)
                {
                    MessageBox.Show("This Auditor already exists!");
                    return;
                }

                Users newUser = frmUserSel.usr;

                if (thisAudit.Supervisor.Id <= 0) 
                {
                    if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Supervisor, newUser.Id))
                    {
                        ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Supervisor = thisAudit.Supervisor }, new Audit() { Id = thisAudit.Id, Supervisor = newUser }, "Audit");
                        MessageBox.Show("Auditors changes on Audit was successful!");
                    }
                }
                
                //refresh
                auditBList = Audit.SelectPending_ToChangeAuditors(); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void MIremoveOwner_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                if (thisAudit.Auditor1.Id > 0 && thisAudit.Auditor2.Id > 0)
                {
                    UserSelector frmUserSel = new UserSelector(new List<Users>() { thisAudit.Auditor1, thisAudit.Auditor2 });
                    if (frmUserSel.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    Users remUser = frmUserSel.usr;

                    //1st or 2nd
                    //-----------------------------                    
                    if (remUser.Id == thisAudit.Auditor1.Id) //1st
                    {
                        bool success = true;
                        //update set 1st = 2nd
                        if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor2, 0))
                        {
                            ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor2 = thisAudit.Auditor2 }, new Audit() { Id = thisAudit.Id, Auditor2 = null }, "Audit");
                        }
                        else
                        {
                            success = false;
                        }
                        if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor1, thisAudit.Auditor2.Id))
                        {
                            ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor1 }, new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor2 }, "Audit");
                        }
                        else
                        {
                            success = false;
                        }
                        if (success)
                        {
                            MessageBox.Show("Auditors changes on Audit was successful!");
                        }
                        //ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor1, Auditor2 = thisAudit.Auditor2 }, new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor2, Auditor2 = null }, "Audit");
                    }
                    else if (remUser.Id == thisAudit.Auditor2.Id) //2nd
                    {
                        //update set 2nd = NULL
                        if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor2, 0))
                        {
                            ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor2 = thisAudit.Auditor2 }, new Audit() { Id = thisAudit.Id, Auditor2 = null }, "Audit");
                            MessageBox.Show("Auditors changes on Audit was successful!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You cannot remove Auditor1! Try 'Change' function instead to update user.");
                }

                //refresh
                auditBList = Audit.SelectPending_ToChangeAuditors(); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void MIremoveSupervisor_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                if (thisAudit.Supervisor.Id > 0)
                {
                    if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Supervisor, 0))
                    {
                        ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Supervisor = thisAudit.Supervisor }, new Audit() { Id = thisAudit.Id, Supervisor = null }, "Audit");
                        MessageBox.Show("Auditors changes on Audit was successful!");
                    }
                }
                else
                {
                    MessageBox.Show("This record has no supervisor to remove!");
                }

                //refresh
                auditBList = Audit.SelectPending_ToChangeAuditors(); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void MIchangeOwner_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                MessageBox.Show("Please select the new auditor to be added.");
                UserSelector frmUserSel = new UserSelector(Users.getAuditors());
                if (frmUserSel.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                //check if already exists...
                if (thisAudit.Auditor1.Id == frmUserSel.usr.Id || thisAudit.Auditor2.Id == frmUserSel.usr.Id || thisAudit.Supervisor.Id == frmUserSel.usr.Id)
                {
                    MessageBox.Show("This Auditor already exists!");
                    return;
                }

                Users newUser = frmUserSel.usr;

                if (thisAudit.Auditor1.Id > 0 && thisAudit.Auditor2.Id > 0)
                {
                    MessageBox.Show("Please select which auditor you want to update.");
                    UserSelector frmUserRemSel = new UserSelector(new List<Users>() { thisAudit.Auditor1, thisAudit.Auditor2 });
                    if (frmUserRemSel.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    Users remUser = frmUserRemSel.usr;

                    if (remUser.Id == thisAudit.Auditor1.Id)
                    {
                        if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor1, newUser.Id))
                        {
                            ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor1 }, new Audit() { Id = thisAudit.Id, Auditor1 = newUser }, "Audit");
                            MessageBox.Show("Auditors changes on Audit was successful!");
                        }
                    }
                    else if (remUser.Id == thisAudit.Auditor2.Id)
                    {
                        if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor2, newUser.Id))
                        {
                            ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor2 = thisAudit.Auditor2 }, new Audit() { Id = thisAudit.Id, Auditor2 = newUser }, "Audit");
                            MessageBox.Show("Auditors changes on Audit was successful!");
                        }
                    }
                }
                else //auditor1
                {
                    if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Auditor1, newUser.Id))
                    {
                        ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Auditor1 = thisAudit.Auditor1 }, new Audit() { Id = thisAudit.Id, Auditor1 = newUser }, "Audit");
                        MessageBox.Show("Auditors changes on Audit was successful!");
                    }
                }

                //refresh
                auditBList = Audit.SelectPending_ToChangeAuditors(); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void MIchangeSupervisor_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int AuditId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Audit thisAudit = auditBList.Where(i => i.Id == AuditId).First();

                int index = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                int rowHandle = gridView1.GetRowHandle(index);

                MessageBox.Show("Please select the new auditor (supervisor) to be added.");
                UserSelector frmUserSel = new UserSelector(Users.getAuditors());
                if (frmUserSel.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                //check if already exists...
                if (thisAudit.Auditor1.Id == frmUserSel.usr.Id || thisAudit.Auditor2.Id == frmUserSel.usr.Id || thisAudit.Supervisor.Id == frmUserSel.usr.Id)
                {
                    MessageBox.Show("This Auditor already exists!");
                    return;
                }

                Users newUser = frmUserSel.usr;

                if (Audit.UpdateAuditor(thisAudit.Id, Audit.AuditOwnerUser.Supervisor, newUser.Id))
                {
                    ChangeLog.Insert(new Audit() { Id = thisAudit.Id, Supervisor = thisAudit.Supervisor }, new Audit() { Id = thisAudit.Id, Supervisor = newUser }, "Audit");
                    MessageBox.Show("Auditors changes on Audit was successful!");
                }

                //refresh
                auditBList = Audit.SelectPending_ToChangeAuditors(); //BindingList
                gridControl1.DataSource = auditBList; //DataSource
                gridView1.FocusedRowHandle = rowHandle;
            }
        }
    }
}
