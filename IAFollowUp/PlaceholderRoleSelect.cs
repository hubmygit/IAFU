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
    public partial class PlaceholderRoleSelect : Form
    {
        public PlaceholderRoleSelect()
        {
            InitializeComponent();
        }

        public PlaceholderRoleSelect(List<PlaceholderRole> phRoles)
        {
            InitializeComponent();

            gridControl1.DataSource = new BindingList<PlaceholderRole>(phRoles.OrderBy(i => i.Role.Id).ToList());
        }

        public int placeholderId = 0;
        public int roleId = 0;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                placeholderId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Placeholder.Id"]).ToString());
                roleId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Role.Id"]).ToString());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
