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
    public partial class OnlyForMigration : Form
    {
        public OnlyForMigration()
        {
            InitializeComponent();
        }

        public OnlyForMigration(string activityDescription)
        {
            InitializeComponent();

            lblActivityDescription.Text += activityDescription;
        }

        public DateTime ALInsDt;
        public string EmailAddr;

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ALInsDt = dtpALInsDt.Value;

            EmailAddr = txtEmail.Text;

            Close();
        }

        private void dtpALInsDt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                DateTime temp;
                if (DateTime.TryParse(Clipboard.GetText(), out temp))
                {
                    dtpALInsDt.Value = temp; //DateTime.Parse(Clipboard.GetText());
                    e.Handled = true;
                }
            }
        }
    }
}
