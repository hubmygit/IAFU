using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class FI_DetailHeaderAudit
    {
        public int AuditId { get; set; }
        public Companies AuditCompany { get; set; }
        public int AuditYear { get; set; }
        public string AuditTitle { get; set; }
        public string AuditRef { get; set; }
        public Users AuditAuditor1 { get; set; }
        public Users AuditAuditor2 { get; set; }
        public Users AuditSupervisor { get; set; }

        //---------------------------------//
        public int HeaderId { get; set; }
        public string HeaderTitle { get; set; }
        public FICategory HeaderCategory { get; set; }
        public string HeaderFIId { get; set; }
        //---------------------------------//
        public int DetailId { get; set; }
        public string DetailDescription { get; set; }
        public DateTime? DetailActionDt { get; set; }
        public string DetailActionReq { get; set; }
        public string DetailActionCode { get; set; }
        public bool DetailIsFinalized { get; set; }
        public string DetailFISubId { get; set; }
        public Owners_MT DetailCurrentOwner1 { get; set; }
        public Owners_MT DetailCurrentOwner2 { get; set; }
        public Owners_MT DetailCurrentOwner3 { get; set; }
        public Owners_MT DetailRealOwner1 { get; set; }
        public Owners_MT DetailRealOwner2 { get; set; }
        public Owners_MT DetailRealOwner3 { get; set; }
        //---------------------------------//
        public ActionSide ActionSide { get; set; }
        public bool IsMyPending { get; set; }

        public FI_DetailHeaderAudit()
        {
        }

        public static BindingList<FI_DetailHeaderAudit> AuditListToDetailList(List<Audit> auditList)
        {
            BindingList<FI_DetailHeaderAudit> ret = new BindingList<FI_DetailHeaderAudit>();

            foreach (Audit thisAudit in auditList) //per audit
            {
                foreach (FIHeader thisHeader in thisAudit.FIHeaders) //per header
                {
                    foreach (FIDetail thisDetail in thisHeader.FIDetails) //per detail
                    {
                        FI_DetailHeaderAudit fiDHA = new FI_DetailHeaderAudit();
                        fiDHA.AuditId = thisAudit.Id;
                        fiDHA.AuditCompany = thisAudit.Company;
                        fiDHA.AuditYear = thisAudit.Year;
                        fiDHA.AuditTitle = thisAudit.Title;
                        fiDHA.AuditRef = thisAudit.AuditRef;
                        fiDHA.AuditAuditor1 = thisAudit.Auditor1;
                        fiDHA.AuditAuditor2 = thisAudit.Auditor2;
                        fiDHA.AuditSupervisor = thisAudit.Supervisor;

                        fiDHA.HeaderId = thisHeader.Id;
                        fiDHA.HeaderTitle = thisHeader.Title;
                        fiDHA.HeaderCategory = thisHeader.FICategory;
                        fiDHA.HeaderFIId = thisHeader.FIId;

                        fiDHA.DetailId = thisDetail.Id;
                        fiDHA.DetailDescription = thisDetail.Description;
                        fiDHA.DetailActionDt = thisDetail.ActionDt;
                        fiDHA.DetailActionReq = thisDetail.ActionReq;
                        fiDHA.DetailActionCode = thisDetail.ActionCode;
                        fiDHA.DetailIsFinalized = thisDetail.IsFinalized;
                        fiDHA.DetailFISubId = thisDetail.FISubId;
                        fiDHA.DetailCurrentOwner1 = thisDetail.CurrentOwner1;
                        fiDHA.DetailCurrentOwner2 = thisDetail.CurrentOwner2;
                        fiDHA.DetailCurrentOwner3 = thisDetail.CurrentOwner3;
                        fiDHA.DetailRealOwner1 = thisDetail.RealOwner1;
                        fiDHA.DetailRealOwner2 = thisDetail.RealOwner2;
                        fiDHA.DetailRealOwner3 = thisDetail.RealOwner3;

                        ActionSide actSide = FIDetailActivity.getActionSide_forAuditors(thisDetail);
                        if (actSide.Id == 2) //auditees
                        {
                            if (thisDetail.IsFinalized)
                            {
                                fiDHA.ActionSide = new ActionSide(3); //none
                            }
                            else
                            {
                                fiDHA.ActionSide = actSide; //auditees
                            }                            
                        }
                        else if (actSide.Id == 1) 
                        {
                            if (thisDetail.IsFinalized)
                            {
                                fiDHA.ActionSide = new ActionSide(3); //none
                            }
                            else
                            {
                                fiDHA.ActionSide = actSide; //auditors
                            }
                        }

                        //mypending
                        fiDHA.IsMyPending = false;
                        if (UserInfo.userDetails.RolesId != 1 && UserInfo.userDetails.RolesId != 5) //admin, GM
                        {
                            fiDHA.IsMyPending = IsMyPendingIssue(fiDHA);
                        }
                        
                        ret.Add(fiDHA);
                    }
                }
            }

            return ret;
        }

        private static bool IsMyPendingIssue(FI_DetailHeaderAudit dha)
        {
            bool ret = true;

            int actionSide = dha.ActionSide.Id;

            if (UserInfo.userDetails.RolesId == 2 && actionSide == 1) //cae 
            {
                if (dha.AuditAuditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditAuditor1.Id) == false)
                {
                    return false;
                }

                if (dha.AuditAuditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditAuditor2.Id) == false)
                {
                    return false;
                }

                if (dha.AuditSupervisor.Id > 0 && FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditSupervisor.Id) == false)
                {
                    return false;
                }

                FICategory fiCat = dha.HeaderCategory;
                List<FIDetailVoting> VotingList = FIDetailVoting.SelectCurrent(dha.DetailId);
                ChiefVoteCause voteCause = FIDetailVoting.doesChiefNeedsToVote(fiCat, VotingList);

                if (voteCause == ChiefVoteCause.None)
                {
                    return false;
                }
            }
            else if (UserInfo.userDetails.RolesId == 3 && actionSide == 1) //auditors
            {
                if (dha.AuditSupervisor.Id == UserInfo.userDetails.Id) //supervisor
                {
                    if (dha.AuditAuditor1.Id > 0 && FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditAuditor1.Id) == false)
                    {
                        return false;
                    }

                    if (dha.AuditAuditor2.Id > 0 && FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditAuditor2.Id) == false)
                    {
                        return false;
                    }

                    if (FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditSupervisor.Id) == true)
                    {
                        return false;
                    }
                }
                else if (dha.AuditAuditor1.Id == UserInfo.userDetails.Id) //auditor1
                {
                    if (FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditAuditor1.Id) == true)
                    {
                        return false;
                    }
                }
                else if (dha.AuditAuditor2.Id == UserInfo.userDetails.Id) //auditor2 
                {
                    if (FIDetailVoting.HasAlreadyVoted(dha.DetailId, dha.AuditAuditor2.Id) == true)
                    {
                        return false;
                    }
                }
                else //other auditors
                {
                    //others - no action
                    return false;
                }
            }
            else if (UserInfo.userDetails.RolesId == 6 && actionSide == 2) //MT
            {
                bool anyOfPhs = false;
                //check placeholders 
                if (dha.DetailCurrentOwner1.User != null && dha.DetailCurrentOwner1.User.Id == UserInfo.userDetails.Id)
                {
                    ActionSide actS = FIDetailActivity.getActionSide_forAuditees(dha.DetailId, dha.DetailCurrentOwner1.Placeholder.Id);
                    if (actS.Id == 2)
                    {
                        anyOfPhs = true;
                    }
                }

                if (dha.DetailCurrentOwner2.User != null && dha.DetailCurrentOwner2.User.Id == UserInfo.userDetails.Id)
                {
                    ActionSide actS = FIDetailActivity.getActionSide_forAuditees(dha.DetailId, dha.DetailCurrentOwner2.Placeholder.Id);
                    if (actS.Id == 2)
                    {
                        anyOfPhs = true;
                    }
                }

                if (dha.DetailCurrentOwner3.User != null && dha.DetailCurrentOwner3.User.Id == UserInfo.userDetails.Id)
                {
                    ActionSide actS = FIDetailActivity.getActionSide_forAuditees(dha.DetailId, dha.DetailCurrentOwner3.Placeholder.Id);
                    if (actS.Id == 2)
                    {
                        anyOfPhs = true;
                    }
                }

                if (anyOfPhs == false)
                {
                    return false;
                }
            }
            else if (UserInfo.userDetails.RolesId == 7 && actionSide == 2) //DT
            {
                //no need to chech for multiple roles (e.g. mt and dt).......at the same detail.....
                bool anyOfPhs = false;
                //check placeholders 
                if (dha.DetailCurrentOwner1.User != null && Owners_DT.IsUserDelegatee(dha.DetailId, dha.DetailCurrentOwner1.Placeholder.Id, UserInfo.userDetails.Id))
                {
                    ActionSide actS = FIDetailActivity.getActionSide_forAuditees(dha.DetailId, dha.DetailCurrentOwner1.Placeholder.Id);
                    if (actS.Id == 2)
                    {
                        anyOfPhs = true;
                    }
                }

                if (dha.DetailCurrentOwner2.User != null && Owners_DT.IsUserDelegatee(dha.DetailId, dha.DetailCurrentOwner2.Placeholder.Id, UserInfo.userDetails.Id))
                {
                    ActionSide actS = FIDetailActivity.getActionSide_forAuditees(dha.DetailId, dha.DetailCurrentOwner2.Placeholder.Id);
                    if (actS.Id == 2)
                    {
                        anyOfPhs = true;
                    }
                }

                if (dha.DetailCurrentOwner3.User != null && Owners_DT.IsUserDelegatee(dha.DetailId, dha.DetailCurrentOwner3.Placeholder.Id, UserInfo.userDetails.Id))
                {
                    ActionSide actS = FIDetailActivity.getActionSide_forAuditees(dha.DetailId, dha.DetailCurrentOwner3.Placeholder.Id);
                    if (actS.Id == 2)
                    {
                        anyOfPhs = true;
                    }
                }

                if (anyOfPhs == false)
                {
                    return false;
                }
            }
            else //never... 
            {
                return false;
            }

            return ret; //true
        }
    }
}
