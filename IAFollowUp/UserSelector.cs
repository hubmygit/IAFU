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
    public partial class UserSelector : Form
    {
        public UserSelector()
        {
            InitializeComponent();
        }

        public UserSelector(List<Users> givenUsersList)
        {
            InitializeComponent();

            usersList = givenUsersList;

            gridControl1.DataSource = new BindingList<Users>(givenUsersList);
        }

        List<Users> usersList = new List<Users>();
        public Users usr = new Users();

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                int usrId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                               
                if (usrId <= 0) //never...
                {
                    MessageBox.Show("Not valid user Id...");
                }
                else
                {
                    usr = new Users(usrId);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
