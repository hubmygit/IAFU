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
    public partial class ViewDepartments : Form
    {
        public ViewDepartments()
        {
            InitializeComponent();

            gridControl1.DataSource = Departments.GetSqlDepartmentsList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
