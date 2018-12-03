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
    public partial class FIHeaderInsert : Form
    {
        public FIHeaderInsert()
        {
            InitializeComponent();
        }

        public FIHeaderInsert(Audit audit) //Insert
        {
            InitializeComponent();

            Init(audit);
            isInsert = true;
            currentAudit = audit;
        }

        public List<FICategory> categoriesList = FICategory.GetSqlFICategoriesList();
        public FIHeaderInsert(Audit audit, FIHeader header) //Update
        {
            InitializeComponent();

            Init(audit);
            isInsert = false;
            currentAudit = audit;

            txtHeaderTitle.Text = header.Title;
            cbCategory.SelectedIndex = cbCategory.FindStringExact(header.FICategory.Name);

            oldHeaderRecord = header;
        }

        public bool isInsert = false;
        //public int HeaderUpdId = 0;
        public bool success = false;
        public Audit currentAudit = new Audit();
        public FIHeader newHeaderRecord = new FIHeader();
        public FIHeader oldHeaderRecord = new FIHeader();

        public void Init(Audit audit)
        {
            txtAuditTitle.Text = audit.Title;
            txtCompany.Text = audit.Company.Name;
            cbCategory.Items.AddRange(FICategory.GetFICategoryComboboxItemsList(categoriesList).ToArray<ComboboxItem>());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHeaderTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a Title!");
                return;
            }

            if (cbCategory.Text.Trim() == "")
            {
                MessageBox.Show("Please choose a Category!");
                return;
            }

            newHeaderRecord = new FIHeader()
            {
                Id = oldHeaderRecord.Id, //only on update, else 0
                Title = txtHeaderTitle.Text,
                FICategory = LibFunctions.getComboboxItem<FICategory>(cbCategory),
                AuditId = currentAudit.Id

                //IsDeleted //?????????
                //IsPublished //?????????

                //Has Details????????????????
            };

            if (isInsert) //insert
            {
                if (FIHeader.Insert(newHeaderRecord))
                {
                    MessageBox.Show("New F/I Header inserted successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The New F/I Header has not been inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //update
            {
                if (FIHeader.Update(newHeaderRecord))
                {
                    ChangeLog.Insert(oldHeaderRecord, newHeaderRecord, "FIHeader");

                    MessageBox.Show("Header updated successfully!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The F/I Header has not been updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
