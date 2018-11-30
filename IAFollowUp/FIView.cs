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
    public partial class FIView : Form
    {
        public FIView()
        {
            InitializeComponent();
        }

        public FIView(Audit givenAudit)
        {
            InitializeComponent();

            gridControl1.DataSource = new BindingList<Audit>() { givenAudit };
        }

    }
}
