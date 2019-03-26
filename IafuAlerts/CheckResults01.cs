using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IafuAlerts
{
    public partial class CheckResults01 : Form
    {
        public CheckResults01()
        {
            InitializeComponent();
        }

        public CheckResults01(BindingList<CheckResults> ChResBList)
        {
            MessageBox.Show("x1");
            InitializeComponent();
            MessageBox.Show("x2");
            gridControl1.DataSource = ChResBList;
            MessageBox.Show("x3");
        }
    }
}
