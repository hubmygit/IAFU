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
        }

        public BindingList<FI_DetailHeaderAudit> fiDHABList = new BindingList<FI_DetailHeaderAudit>();

        private void button1_Click(object sender, EventArgs e)
        {
            gridView1.Columns[4].Group();
            gridView1.Columns[8].Group();
            gridView1.Columns[15].Group();
            gridView1.ExpandAllGroups();
        }

        private void MIactivity_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int detId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["DetailId"]).ToString());
                                
                if (UserAction.IsLegal(Action.FI_Activity_View))
                {
                    FIActivity frmActivity = new FIActivity(detId);
                    frmActivity.ShowDialog();
                }
            }
        }

    }

    public class FI_DetailHeaderAudit
    {
        public int AuditId { get; set; }
        public Companies AuditCompany { get; set; }
        public int AuditYear { get; set; }
        public string AuditTitle { get; set; }
        public string AuditRef { get; set; }
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
                        fiDHA.AuditRef = thisAudit.AuditRef;
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

                        ret.Add(fiDHA);
                    }
                }
            }

            return ret;
        }
    }

}
