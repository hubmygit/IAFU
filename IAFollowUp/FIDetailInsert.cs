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
    public partial class FIDetailInsert : Form
    {
        public FIDetailInsert()
        {
            InitializeComponent();
        }

        public FIDetailInsert(Audit audit, FIHeader header) //insert
        {
            InitializeComponent();

            Init(audit, header);
            isInsert = true;
            currentAudit = audit;
            currentHeader = header;

            //gridControl1.DataSource = new BindingList<DetailOwners>(DetailOwners.GetCurrentDetailOwnersListPerCompany(audit.Company.Id));
        }

        public FIDetailInsert(Audit audit, FIHeader header, FIDetail detail, bool IsInsertion) //update - duplicate
        {
            InitializeComponent();

            Init(audit, header);
            isInsert = IsInsertion; //false - update, true - duplicate
            currentAudit = audit;
            currentHeader = header;

            //gridControl1.DataSource = new BindingList<DetailOwners>(DetailOwners.GetCurrentDetailOwnersListPerCompany(audit.Company.Id));

            txtDescription.Text = detail.Description;
            txtActionCode.Text = detail.ActionCode;
            if (detail.ActionDt != null)
            {
                dtpActionDate.Value = (DateTime)detail.ActionDt;
            }
            txtActionReq.Text = detail.ActionReq;

            //fIDetail.Owners = fIDetail.getOwners(fIDetail.Id, fIDetail.RevNo);
            //foreach (Users thisOwner in detail.Owners)
            //{
            //    dgvOwners.Rows.Add(new object[] { thisOwner.Id, thisOwner.FullName, thisOwner.RoleName });
            //}

            foreach (Placeholders thisPlaceholder in detail.Placeholders)
            {
                DataGridViewRow row =dgvAllOwners.Rows
                                    .Cast<DataGridViewRow>()
                                    .Where(r => Convert.ToInt32(r.Cells["Placeholders_Id"].Value.ToString()) == thisPlaceholder.Id)
                                    .First();

                if (row.Index >= 0)
                {
                    dgvAllOwners["IsOwner", row.Index].Value = "True";
                }
            }
            //foreach (int countryId in givenRec.CountryIds)
            //{
            //    DataGridViewRow row = dgvCountries.Rows
            //                          .Cast<DataGridViewRow>()
            //                          .Where(r => Convert.ToInt32(r.Cells["Country_Id"].Value.ToString()) == countryId)
            //                          .First();

            //    if (row.Index >= 0)
            //    {
            //        dgvCountries["Country_Checked", row.Index].Value = "True";
            //    }
            //}


            if (IsInsertion == false)
            {
                oldDetailRecord = detail;
            }
        }

        public bool isInsert = false;
        public bool success = false;
        public Audit currentAudit = new Audit();
        public FIHeader currentHeader = new FIHeader();
        public FIDetail newDetailRecord = new FIDetail();
        public FIDetail oldDetailRecord = new FIDetail();

        public List<Users> ownersList = Users.GetUsersByRole(UserRole.IsAuditee);

        public void Init(Audit audit, FIHeader header)
        {
            //FullName.Items.AddRange(ownersList.Select(i => i.FullName).OrderBy(i => i).ToArray());

            List<DetailOwners> AllDetailOwners = DetailOwners.GetCurrentDetailOwnersListPerCompany(audit.Company.Id);
            foreach (DetailOwners thisOwner in AllDetailOwners)
            {
                dgvAllOwners.Rows.Add(new object[] { false, thisOwner.Id, thisOwner.Placeholder.Id, thisOwner.User.Id, thisOwner.Placeholder.Department.Name, thisOwner.User.FullName });
            }

            txtAuditTitle.Text = audit.Title;
            txtCompany.Text = audit.Company.Name;

            txtCategory.Text = header.FICategory.Name;
            txtHeaderTitle.Text = header.Title;
        }

        private void dtpActionDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtpActionDate.CustomFormat = " ";
            }
        }

        private void dtpActionDate_ValueChanged(object sender, EventArgs e)
        {
            dtpActionDate.CustomFormat = "dd.MM.yyyy";
        }

        //private void dgvOwners_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //    {
        //        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvOwners.Rows[e.RowIndex].Cells["FullName"];

        //        if (cb.Value != null)
        //        {
        //            dgvOwners.Invalidate();
        //        }
        //    }
        //}

        //private void dgvOwners_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (dgvOwners.IsCurrentCellDirty)
        //    {
        //        bool commited = false;

        //        // This fires the cell value changed handler below
        //        try
        //        {
        //            commited = dgvOwners.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Commited: " + commited + " / " + ex.Message);
        //        }
        //        //MessageBox.Show(dgvOwners.SelectedRows[0].Cells["FullName"].Value.ToString());

        //        dgvOwners.SelectedRows[0].Cells["Id"].Value = ownersList.Where(i => i.FullName == dgvOwners.SelectedRows[0].Cells["FullName"].Value.ToString()).First().Id;
        //        dgvOwners.SelectedRows[0].Cells["Role"].Value = ownersList.Where(i => i.FullName == dgvOwners.SelectedRows[0].Cells["FullName"].Value.ToString()).First().RoleName;

        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Description!");
                return;
            }

            if (txtActionReq.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Action Required!");
                return;
            }

            if (txtActionCode.Text.Trim() == "")
            {
                MessageBox.Show("Please insert an Action Code!");
                return;
            }

            //List<Users> newOwners = new List<Users>();
            //for (int l = 0; l < dgvOwners.Rows.Count; l++)
            //{
            //    if (dgvOwners.Rows[l].IsNewRow == false)
            //    {
            //        newOwners.Add(new Users()
            //        {
            //            Id = Convert.ToInt32(dgvOwners.Rows[l].Cells["Id"].Value.ToString()),
            //            FullName = dgvOwners.Rows[l].Cells["FullName"].Value.ToString(),
            //            RoleName = dgvOwners.Rows[l].Cells["Role"].Value.ToString()
            //        });
            //    }
            //}

            List<Placeholders> newPlaceholders = new List<Placeholders>();
            for (int l = 0; l < dgvAllOwners.Rows.Count; l++)
            {
                if (Convert.ToBoolean(dgvAllOwners.Rows[l].Cells["IsOwner"].Value.ToString()))
                {
                    newPlaceholders.Add(new Placeholders(Convert.ToInt32(dgvAllOwners.Rows[l].Cells["Placeholders_Id"].Value.ToString())));
                }
            }
            

            //if (newOwners.Count <= 0)
            //{
            //    MessageBox.Show("Please insert at least one Owner!");
            //    return;
            //}

            if (newPlaceholders.Count <= 0)
            {
                MessageBox.Show("Please insert at least one Owner!");
                return;
            }

            DateTime? dt_Action = new DateTime();
            if (dtpActionDate.CustomFormat != " ")
            {
                dt_Action = dtpActionDate.Value;
            }
            else
            {
                dt_Action = null;
            }

            newDetailRecord = new FIDetail()
            {
                Id = oldDetailRecord.Id,
                Description = txtDescription.Text,
                //Description = txtDescription.Text.Replace('\r', ' ').Replace('\n', ' '),
                ActionCode = txtActionCode.Text,
                ActionReq = txtActionReq.Text,
                //ActionReq = txtActionReq.Text.Replace('\r', ' ').Replace('\n', ' '),
                ActionDt = dt_Action,
                //OwnersCnt = oldFIDetailRecord.OwnersCnt,
                //Owners = newOwners,
                Placeholders = newPlaceholders,
                FIHeaderId = currentHeader.Id,
                //AttCnt = oldFIDetailRecord.AttCnt

                IsClosed = chbIsClosed.Checked
            };

            if (isInsert) //insert
            {
                if (FIDetail.Insert(newDetailRecord))
                {
                    MessageBox.Show("New F/I Detail inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New F/I Detail has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (FIDetail.Update(newDetailRecord))
                {
                    ChangeLog.Insert(oldDetailRecord, newDetailRecord, "FIDetail");

                    MessageBox.Show("F/I Detail updated successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The F/I Detail has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
