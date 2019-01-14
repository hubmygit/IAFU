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
        public FIView_Auditees()
        {
            InitializeComponent();

            List<FIDetail> detailList = FIDetail.Select(UserInfo.roleDetails.IsAdmin);

            //UserInfo.userDetails.Id

            //a) Admin
            //   Όλα
            //b) Auditor
            //   Όλα τα published
            //c) MT
            //d) GM
            //e) Delegatee 

            List<FIHeader> headerList = FIHeader.Select(UserInfo.roleDetails.IsAdmin, detailList);
            List<Audit> auditList = Audit.Select(UserInfo.roleDetails.IsAdmin, headerList);
            
            fiDHABList = FI_DetailHeaderAudit.AuditListToDetailList(auditList);
            gridControl1.DataSource = fiDHABList;

            //gridView1.Columns["IsDeleted"].Visible = UserInfo.roleDetails.IsAdmin;



            gridControlFI.DataSource = new BindingList<Audit>(auditList);
        }

        public BindingList<FI_DetailHeaderAudit> fiDHABList = new BindingList<FI_DetailHeaderAudit>();

    }

    public class FI_DetailHeaderAudit
    {
        public int AuditId { get; set; }
        public Companies AuditCompany { get; set; }
        public int AuditYear { get; set; }
        public string AuditTitle { get; set; }
        //---------------------------------//
        public int HeaderId { get; set; }
        public string HeaderTitle { get; set; }
        public FICategory HeaderCategory { get; set; }
        //---------------------------------//
        public int DetailId { get; set; }
        public string DetailDescription { get; set; } 
        public DateTime? DetailActionDt { get; set; } 
        public string DetailActionReq { get; set; } 
        public bool DetailIsFinalized { get; set; }

        public FI_DetailHeaderAudit()
        {              
        }

        public static BindingList<FI_DetailHeaderAudit>  AuditListToDetailList(List<Audit> auditList)
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
                        fiDHA.HeaderId = thisHeader.Id;
                        fiDHA.HeaderTitle = thisHeader.Title;
                        fiDHA.HeaderCategory = thisHeader.FICategory;
                        fiDHA.DetailId = thisDetail.Id;
                        fiDHA.DetailDescription = thisDetail.Description;
                        fiDHA.DetailActionDt = thisDetail.ActionDt;
                        fiDHA.DetailActionReq = thisDetail.ActionReq;
                        fiDHA.DetailIsFinalized = thisDetail.IsFinalized;

                        ret.Add(fiDHA);
                    }
                }
            }

            return ret;
        }
    }

}
