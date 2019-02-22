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

        public ActionSide ActionSide { get; set; }

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

                        ActionSide actSide = FIDetailActivity.getActionSide_forAuditors(thisDetail);
                        if (actSide.Id == 2) //auditees
                        {
                            fiDHA.ActionSide = actSide;
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

                        ret.Add(fiDHA);
                    }
                }
            }

            return ret;
        }
    }
}
