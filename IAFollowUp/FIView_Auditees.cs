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
    public partial class FIView_Auditees : Form
    {
        public FIView_Auditees() //(bool showAuditors)
        {
            InitializeComponent();

            detailList = FIDetail.Select(UserInfo.roleDetails.IsAdmin);

            
            //UserInfo.userDetails.Id

            //a) Admin
            //   Όλα
            //b) Auditor
            //   Όλα τα published
            //c) MT
            //   Όλα τα published των placeholders του
            //d) GM
            //   Όλα τα published των placeholders του
            //e) Delegatee
            //   Όλα τα published των placeholders του Detail του

            List<FIHeader> headerList = FIHeader.Select(UserInfo.roleDetails.IsAdmin, detailList);
            List<Audit> auditList = Audit.Select(UserInfo.roleDetails.IsAdmin, headerList);
            
            fiDHABList = FI_DetailHeaderAudit.AuditListToDetailList(auditList);
            gridControl1.DataSource = fiDHABList;


            //gridView1.Columns["IsDeleted"].Visible = UserInfo.roleDetails.IsAdmin;

            //gridControlFI.DataSource = new BindingList<Audit>(auditList);


            //if (showAuditors == false)
            //{
            //    gridView1.Columns["AuditAuditor1.FullName"].Visible = false;
            //    gridView1.Columns["AuditAuditor2.FullName"].Visible = false;
            //    gridView1.Columns["AuditSupervisor.FullName"].Visible = false;
            //}
        }

        public BindingList<FI_DetailHeaderAudit> fiDHABList = new BindingList<FI_DetailHeaderAudit>();
        public List<FIDetail> detailList = new List<FIDetail>();

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    gridView1.Columns[4].Group();
        //    gridView1.Columns[8].Group();
        //    gridView1.Columns[15].Group();
        //    gridView1.ExpandAllGroups();
        //}

        private void MIactivity_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int detId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["DetailId"]).ToString());
                FIDetail det = detailList.Where(i => i.Id == detId).First();

                int auditeePh = 0;
                int auditeeRole = 0;

                if (UserInfo.roleDetails.IsAuditee) //check for multiple placeholders
                {
                    List<PlaceholderRole> phRole = new List<PlaceholderRole>();
                     
                    foreach (Placeholders ph in det.Placeholders)
                    {
                        if (Owners_MT.GetCurrentOwnerMT(ph.Id).User.Id == UserInfo.userDetails.Id)
                        {
                            phRole.Add(new PlaceholderRole() { Placeholder = ph, Role = new AuditeesRoles(2) });
                        }

                        foreach (Users userGm in Owners_GM.GetOwnerGMUsersList(ph.Id))
                        {
                            if (userGm.Id == UserInfo.userDetails.Id)
                            {
                                if (phRole.Count(i => i.Role.Id == 1) < 1) //if contains 1, don't add other records (1 gm record is enough!)
                                {
                                    phRole.Add(new PlaceholderRole() { Placeholder = new Placeholders() { Id = 0, Company = ph.Company }, Role = new AuditeesRoles(1) });
                                }
                            }
                        }

                        foreach (Users userDt in Owners_DT.GetOwnerDTUsersList(det.Id, ph.Id))
                        {
                            if (userDt.Id == UserInfo.userDetails.Id)
                            {
                                phRole.Add(new PlaceholderRole() { Placeholder = ph, Role = new AuditeesRoles(3) });
                            }
                        }
                    }

                    if (phRole.Count > 1) 
                    {
                        MessageBox.Show("You have multiple Roles in this Detail! Please select one of the following roles.");
                        PlaceholderRoleSelect frmPlaceholderRole = new PlaceholderRoleSelect(phRole);
                        if (frmPlaceholderRole.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                        else
                        {
                            auditeePh = frmPlaceholderRole.placeholderId;
                            auditeeRole = frmPlaceholderRole.roleId;
                        }
                    }
                    else if(phRole.Count == 1) //just 1 role
                    {
                        auditeePh = phRole[0].Placeholder.Id;
                        auditeeRole = phRole[0].Role.Id;
                    }
                    //else //error - no role
                    //{
                    //    return;
                    //}
                }

                if (UserAction.IsLegal(Action.Activity_View))
                {
                    FIActivity frmActivity = new FIActivity(det, auditeePh, auditeeRole);
                    frmActivity.ShowDialog();
                }
            }
        }

    }

    

}
