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
    public partial class DeadlineExtension : Form
    {
        public DeadlineExtension()
        {
            InitializeComponent();
        }

        public DeadlineExtension(DateTime? ActionDate, int detailId = 0)
        {
            InitializeComponent();

            if (ActionDate != null)
            {
                dtpCurrentActionDate.CustomFormat = "dd.MM.yyyy";
                dtpCurrentActionDate.Value = (DateTime)ActionDate;
            }

            //"Deadline Extension(s): "
            lblDeadlineExtensions.Text += FIDetailActivity.getDeadlineExtensions(detailId).Count.ToString();
        }

        public DateTime newActionDate;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpNewActionDate.CustomFormat == " ")
            {
                MessageBox.Show("Please insert a valid Action Date!");
                return;
            }

            if (dtpNewActionDate.Value < dtpCurrentActionDate.Value)
            {
                MessageBox.Show("New Action Date must be more recent from Current Action Date!");
                return;
            }

            if (Migration.migrationMode == false)
            {
                if (dtpNewActionDate.Value < DateTime.Now)
                {
                    MessageBox.Show("New Action Date cannot belong to the past!");
                    return;
                }
            }

            newActionDate = dtpNewActionDate.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void dtpNewActionDate_ValueChanged(object sender, EventArgs e)
        {
            dtpNewActionDate.CustomFormat = "dd.MM.yyyy";
        }

        private void dtpNewActionDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtpNewActionDate.CustomFormat = " ";
            }
        }

    }
}
