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
    public partial class ChangeLogView : Form
    {
        public ChangeLogView()
        {
            InitializeComponent();

            changeLogBList = ChangeLog.Select();
            gridControl1.DataSource = changeLogBList;
        }

        public BindingList<ChangeLog> changeLogBList = new BindingList<ChangeLog>();


    }
}
