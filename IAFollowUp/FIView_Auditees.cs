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

        private void chbNotFinalized_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNotFinalized.Checked)
            {
                BindingList<FI_DetailHeaderAudit> FilteredList = new BindingList<FI_DetailHeaderAudit>(fiDHABList.Where(i => i.DetailIsFinalized == false).ToList());
                gridControl1.DataSource = FilteredList;
            }
            else
            {
                gridControl1.DataSource = fiDHABList;
            }


            //gridView1.RowStyle += (sender2, e2) =>
            //{
            //    if (Convert.ToBoolean(gridView1.GetRowCellValue(e2.RowHandle, gridView1.Columns["DetailIsFinalized"])))
            //    {
            //    }
            //};
        }

        private void chbMine_CheckedChanged(object sender, EventArgs e)
        {
            Color initColor = gridView1.Appearance.Row.BackColor;
            
            if (chbMine.Checked)
            {                
                if (UserInfo.userDetails.RolesId == 1) //admin
                {
                    //do nothing - no actions
                    return;
                }

                if (UserInfo.userDetails.RolesId == 5) //GM
                {
                    //do nothing - no actions
                    return;
                }

                
                gridView1.RowStyle += (sender2, e2) =>
                {
                    if (e2.RowHandle < 0)
                    {
                        return;
                    }

                    int detId = Convert.ToInt32(gridView1.GetRowCellValue(e2.RowHandle, gridView1.Columns["DetailId"]).ToString());
                    //FIDetail det = detailList.Where(i => i.Id == detId).First();
                    FI_DetailHeaderAudit dha = fiDHABList.Where(i => i.DetailId == detId).First();

                    //int actionSide = Convert.ToInt32(gridView1.GetRowCellValue(e2.RowHandle, gridView1.Columns["ActionSide.Id"]).ToString());
                    int actionSide = dha.ActionSide.Id;


                    if (UserInfo.userDetails.RolesId == 2 && actionSide == 1) //cae 
                    {
                        if (dha.AuditAuditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(detId, dha.AuditAuditor1.Id) == false)
                        {
                            return;
                        }

                        if (dha.AuditAuditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(detId, dha.AuditAuditor2.Id) == false)
                        {
                            return;
                        }

                        if (dha.AuditSupervisor.Id > 0 && FIDetailVoting.HasAlreadyVoted(detId, dha.AuditSupervisor.Id) == false)
                        {
                            return;
                        }

                        FICategory fiCat = dha.HeaderCategory; //completeAudit.FIHeaders[0].FICategory;
                        List<FIDetailVoting> VotingList = FIDetailVoting.SelectCurrent(detId);
                        ChiefVoteCause voteCause = FIDetailVoting.doesChiefNeedsToVote(fiCat, VotingList);

                        if (voteCause == ChiefVoteCause.None)
                        {
                            return;
                        }
                    }
                    else if (UserInfo.userDetails.RolesId == 3 && actionSide == 1) //auditors
                    {
                        if (dha.AuditSupervisor.Id == UserInfo.userDetails.Id) //supervisor
                        {
                            if (dha.AuditAuditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(detId, dha.AuditAuditor1.Id) == false)
                            {
                                return;
                            }

                            if (dha.AuditAuditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(detId, dha.AuditAuditor2.Id) == false)
                            {
                                return;
                            }

                            if (FIDetailVoting.HasAlreadyVoted(detId, dha.AuditSupervisor.Id) == true)
                            {
                                return;
                            }
                        }
                        else if (dha.AuditAuditor1.Id == UserInfo.userDetails.Id) //auditor1
                        {
                            if (FIDetailVoting.HasAlreadyVoted(detId, dha.AuditAuditor1.Id) == true)
                            {
                                return;
                            }
                        }
                        else if (dha.AuditAuditor2.Id == UserInfo.userDetails.Id) //auditor2 
                        {
                            if (FIDetailVoting.HasAlreadyVoted(detId, dha.AuditAuditor2.Id) == true)
                            {
                                return;
                            }
                        }
                        else //other auditors
                        {
                            //others - no action
                            return;
                        }
                    }
                    else if (UserInfo.userDetails.RolesId == 6 && actionSide == 2) //MT
                    {
                        bool anyOfPhs = false;
                        //check placeholders 
                        if (dha.DetailCurrentOwner1.User != null && dha.DetailCurrentOwner1.User.Id == UserInfo.userDetails.Id)
                        {
                            ActionSide actS = FIDetailActivity.getActionSide_forAuditees(detId, dha.DetailCurrentOwner1.Placeholder.Id);
                            if (actS.Id == 2)
                            {
                                anyOfPhs = true;
                            }
                        }

                        if (dha.DetailCurrentOwner2.User != null && dha.DetailCurrentOwner2.User.Id == UserInfo.userDetails.Id)
                        {
                            ActionSide actS = FIDetailActivity.getActionSide_forAuditees(detId, dha.DetailCurrentOwner2.Placeholder.Id);
                            if (actS.Id == 2)
                            {
                                anyOfPhs = true;
                            }
                        }

                        if (dha.DetailCurrentOwner3.User != null && dha.DetailCurrentOwner3.User.Id == UserInfo.userDetails.Id)
                        {
                            ActionSide actS = FIDetailActivity.getActionSide_forAuditees(detId, dha.DetailCurrentOwner3.Placeholder.Id);
                            if (actS.Id == 2)
                            {
                                anyOfPhs = true;
                            }
                        }

                        if (anyOfPhs == false)
                        {
                            return;
                        }
                    }
                    else if (UserInfo.userDetails.RolesId == 7 && actionSide == 2) //DT
                    {
                        //no need to chech for multiple roles (e.g. mt and dt).......at the same detail.....
                        bool anyOfPhs = false;
                        //check placeholders 
                        if (dha.DetailCurrentOwner1.User != null && Owners_DT.IsUserDelegatee(detId, dha.DetailCurrentOwner1.Placeholder.Id, UserInfo.userDetails.Id))
                        {
                            ActionSide actS = FIDetailActivity.getActionSide_forAuditees(detId, dha.DetailCurrentOwner1.Placeholder.Id);
                            if (actS.Id == 2)
                            {
                                anyOfPhs = true;
                            }
                        }

                        if (dha.DetailCurrentOwner2.User != null && Owners_DT.IsUserDelegatee(detId, dha.DetailCurrentOwner2.Placeholder.Id, UserInfo.userDetails.Id))
                        {
                            ActionSide actS = FIDetailActivity.getActionSide_forAuditees(detId, dha.DetailCurrentOwner2.Placeholder.Id);
                            if (actS.Id == 2)
                            {
                                anyOfPhs = true;
                            }
                        }

                        if (dha.DetailCurrentOwner3.User != null && Owners_DT.IsUserDelegatee(detId, dha.DetailCurrentOwner3.Placeholder.Id, UserInfo.userDetails.Id))
                        {
                            ActionSide actS = FIDetailActivity.getActionSide_forAuditees(detId, dha.DetailCurrentOwner3.Placeholder.Id);
                            if (actS.Id == 2)
                            {
                                anyOfPhs = true;
                            }
                        }

                        if (anyOfPhs == false)
                        {
                            return;
                        }
                    }
                    else //never... 
                    {
                        return;
                    }
                                                                                          
                    e2.Appearance.BackColor = Color.LightBlue;
                    e2.HighPriority = true;
                };
                
                gridView1.Focus();
            }
            else
            {
                gridView1.RowStyle += (sender2, e2) =>
                {
                    e2.Appearance.BackColor = initColor;
                    e2.HighPriority = true;
                };
                gridView1.Focus();
            }
        }

        

    }

    

}
