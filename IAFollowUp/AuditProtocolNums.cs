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
    public partial class AuditProtocolNums : Form
    {
        public AuditProtocolNums()
        {
            InitializeComponent();
        }

        public AuditProtocolNums(Audit audit)
        {
            InitializeComponent();

            currentAudit = audit;
            //newAuditRecord = audit;

            txtAuditTitle.Text = audit.Title;
            txtCompany.Text = audit.Company.Name;

            txtAuditNumber.Text = audit.AuditNumber;
            txtIASentNumber.Text = audit.IASentNumber;
            dtpReportDate.Value = audit.ReportDt;
        }

        public Audit currentAudit = new Audit();
        public Audit newAuditRecord = new Audit();
        public bool success = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAuditNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Audit Number!");
                return;
            }
            if (txtIASentNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an IA Sent Number!");
                return;
            }

            newAuditRecord.Id = currentAudit.Id;
            newAuditRecord.AuditNumber = txtAuditNumber.Text.Trim();
            newAuditRecord.IASentNumber = txtIASentNumber.Text.Trim();
            newAuditRecord.ReportDt = dtpReportDate.Value.Date;
            newAuditRecord.AuditRef = txtAuditRef.Text.Trim();

            if (Audit.UpdateProtocolNums(newAuditRecord))//check if newAuditRecord and currentAudit have diff values (reference??)
            {
                ChangeLog.Insert(new Audit() { Id = currentAudit.Id,
                                               AuditNumber = currentAudit.AuditNumber,
                                               IASentNumber = currentAudit.IASentNumber,
                                               ReportDt = currentAudit.ReportDt,
                                               AuditRef = currentAudit.AuditRef }, 
                                 new Audit() { Id = currentAudit.Id,
                                               AuditNumber = newAuditRecord.AuditNumber,
                                               IASentNumber = newAuditRecord.IASentNumber,
                                               ReportDt = newAuditRecord.ReportDt,
                                               AuditRef =newAuditRecord.AuditRef }, 
                                 "AuditProtocolNums");

                MessageBox.Show("Protocol Numbers and Report Date updated successfully!");
                success = true;
                Close();
            }
            else
            {
                MessageBox.Show("Protocol Numbers and Report Date have not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        void AuditRefAutoCompleteProtokNums()
        {
            string year = "____";
            if (currentAudit.Year.ToString() != "")
            {
                year = currentAudit.Year.ToString();
            }

            string com = "__";  //LibFunctions.getComboboxItem<Companies>(cbCompanies).NameShort;
            if (currentAudit.Company.NameShort.Trim() != "")
            {
                com = currentAudit.Company.NameShort.Trim();
            }

            string aNum = "___";
            if (txtAuditNumber.Text.Trim() != "")
            {
                aNum = txtAuditNumber.Text.Trim();
            }

            string aType = "__";  //LibFunctions.getComboboxItem<Companies>(cbCompanies).NameShort;
            if (currentAudit.AuditType.NameShort.Trim() != "")
            {
                aType = currentAudit.AuditType.NameShort.Trim();
            }

            string iaSentNum = "___";
            if (txtIASentNumber.Text.Trim() != "")
            {
                iaSentNum = txtIASentNumber.Text.Trim();
            }

            txtAuditRef.Text = year + "." + com + "." + aNum + "." + aType + "-" + iaSentNum;
        }

        private void txtAuditNumber_TextChanged(object sender, EventArgs e)
        {
            AuditRefAutoCompleteProtokNums();
        }

        private void txtIASentNumber_TextChanged(object sender, EventArgs e)
        {
            AuditRefAutoCompleteProtokNums();
        }
    }
}
