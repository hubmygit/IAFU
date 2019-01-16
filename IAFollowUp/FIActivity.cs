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
    public partial class FIActivity : Form
    {
        public FIActivity()
        {
            InitializeComponent();
        }

        public FIActivity(int detailId)
        {
            InitializeComponent();

            gridControl1.DataSource = new BindingList<FIDetailActivity>(FIDetailActivity.getDetailActivity(detailId)); 
        }

    }
}
