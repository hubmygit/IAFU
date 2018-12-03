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
    public partial class AuditInsert : Form
    {
        public AuditInsert() //Insert
        {
            InitializeComponent();

            Init();
            isInsert = true;
        }

        public AuditInsert(Audit audit) //Update
        {
            InitializeComponent();

            Init();
            isInsert = false;

            oldAuditRecord = audit;
            AuditUpdId = audit.Id;

            txtTitle.Text = audit.Title;
            dtpYear.Value = new DateTime(audit.Year, 1, 1);

            cbCompanies.SelectedIndex = cbCompanies.FindStringExact(audit.Company.Name);

            txtAuditNumber.Text = audit.AuditNumber;
            txtIASentNumber.Text = audit.IASentNumber;
            dtpReportDate.Value = audit.ReportDt;

            cbAuditTypes.SelectedIndex = cbAuditTypes.FindStringExact(audit.AuditType.Name);
            cbAuditor1.SelectedIndex = cbAuditor1.FindStringExact(audit.Auditor1.FullName);

            if (audit.Auditor2 != null)
            {
                cbAuditor2.SelectedIndex = cbAuditor2.FindStringExact(audit.Auditor2.FullName);
            }
            if (audit.Supervisor != null)
            {
                cbSupervisor.SelectedIndex = cbSupervisor.FindStringExact(audit.Supervisor.FullName);
            }
            if (audit.AuditRating != null)
            {
                cbRating.SelectedIndex = cbRating.FindStringExact(audit.AuditRating.Name);
            }
        }

        public void Init()
        {
            cbCompanies.Items.AddRange(Companies.GetCompaniesComboboxItemsList(companiesList).ToArray<ComboboxItem>());
            cbAuditTypes.Items.AddRange(AuditTypes.GetAuditTypesComboboxItemsList(auditTypesList).ToArray<ComboboxItem>());
            cbAuditor1.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbAuditor2.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbSupervisor.Items.AddRange(Users.GetUsersComboboxItemsList(usersList).ToArray<ComboboxItem>());
            cbRating.Items.AddRange(AuditRating.GetAuditRatingComboboxItemsList(auditRatingList).ToArray<ComboboxItem>());
        }

        public List<Companies> companiesList = Companies.GetSqlCompaniesList();
        public List<AuditTypes> auditTypesList = AuditTypes.GetSqlAuditTypesList();
        public List<Users> usersList = Users.GetUsersByRole(UserRole.IsAuditor); //Users.GetSqlUsersList();
        public List<AuditRating> auditRatingList = AuditRating.GetSqlAuditRatingList();

        public bool isInsert = false;
        public int AuditUpdId = 0;
        public bool success = false;

        public Audit oldAuditRecord = new Audit();
        public Audit newAuditRecord = new Audit();

        private void btnEraseAuditor2_Click(object sender, EventArgs e)
        {
            cbAuditor2.SelectedIndex = -1;
        }

        private void btnEraseSupervisor_Click(object sender, EventArgs e)
        {
            cbSupervisor.SelectedIndex = -1;
        }

        private void btnEraseRating_Click(object sender, EventArgs e)
        {
            cbRating.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Title!");
                return;
            }
            //if (txtAuditNumber.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please insert an Audit Number!");
            //    return;
            //}
            //if (txtIASentNumber.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please insert a IA Sent Number!");
            //    return;
            //}
            if (cbCompanies.Text.Trim() == "")
            {
                MessageBox.Show("Please choose a Company!");
                return;
            }

            if (cbAuditTypes.Text.Trim() == "")
            {
                MessageBox.Show("Please choose an Audit Type!");
                return;
            }

            if (cbAuditor1.Text.Trim() == "")
            {
                MessageBox.Show("Please choose an Auditor1 User!");
                return;
            }

            newAuditRecord = new Audit()
            {
                AuditNumber = txtAuditNumber.Text,
                Auditor1 = LibFunctions.getComboboxItem<Users>(cbAuditor1),
                Company = LibFunctions.getComboboxItem<Companies>(cbCompanies),
                AuditType = LibFunctions.getComboboxItem<AuditTypes>(cbAuditTypes),
                IASentNumber = txtIASentNumber.Text,
                Title = txtTitle.Text,
                Year = dtpYear.Value.Year,
                ReportDt = dtpReportDate.Value.Date,
                IsCompleted = false,

                Id = AuditUpdId//, //only on update
                //AttCnt = oldAuditRecord.AttCnt
            };

            if (cbAuditor2.SelectedIndex > -1)
            {
                newAuditRecord.Auditor2 = LibFunctions.getComboboxItem<Users>(cbAuditor2);
            }
            else
            {
                newAuditRecord.Auditor2 = new Users();
            }

            if (cbSupervisor.SelectedIndex > -1)
            {
                newAuditRecord.Supervisor = LibFunctions.getComboboxItem<Users>(cbSupervisor);
            }
            else
            {
                newAuditRecord.Supervisor = new Users();
            }

            if (cbRating.SelectedIndex > -1)
            {
                newAuditRecord.AuditRating = LibFunctions.getComboboxItem<AuditRating>(cbRating);
            }
            else
            {
                newAuditRecord.AuditRating = new AuditRating();
            }

            //--------------------------------            

            if (isInsert) //insert
            {
                if (Audit.Insert(newAuditRecord))
                {
                    MessageBox.Show("New Audit inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New Audit has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (Audit.Update(newAuditRecord))
                {                   
                    ChangeLog.Insert(oldAuditRecord, newAuditRecord, "Audit");
                    
                    MessageBox.Show("Audit updated successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The Audit has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }
    }
}
