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
    public partial class DelegateesSelect : Form
    {
        public DelegateesSelect()
        {
            InitializeComponent();
        }

        public DelegateesSelect(int detailId, int placeholderId) //MT delegate DT
        {
            InitializeComponent();
            OnComment = false;

            detId = detailId;
            phId = placeholderId;

            List<Users> phDelegatees = Delegatees.GetDelegateesUsersList(placeholderId);

            gridControl1.DataSource = new BindingList<Users>(phDelegatees);

            for (int i = 0; i < gridView1.RowCount; i++)
            {                
                int thisUserId = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["Id"]));
                if (Owners_DT.IsUserDelegatee(detId, phId, thisUserId))
                {
                    int aaaa = 0;
                }
            }

        }

        public DelegateesSelect(List<Users> delegatees) //MT reply to DT
        {
            InitializeComponent();
            OnComment = true;

            gridControl1.DataSource = new BindingList<Users>(delegatees);
        }

        public int usrId = 0;
        public int detId = 0;
        public int phId = 0;
        bool OnComment = false;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                usrId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());

                if (OnComment == false)
                {
                    if (Owners_DT.IsUserDelegatee(detId, phId, usrId))
                    {
                        MessageBox.Show("This User is already Delegatee for this Detail!");
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }

    }
}
