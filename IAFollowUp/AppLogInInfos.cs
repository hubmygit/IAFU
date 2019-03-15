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
    public partial class AppLogInInfos : Form
    {
        public AppLogInInfos()
        {
            InitializeComponent();

            BindingList<AppLogIn> AppLogInsBList = AppLogIn.AppLogInList();

            gridControl1.DataSource = AppLogInsBList;
        }
    }
}
