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

            detId = detailId;
            detailActivity = FIDetailActivity.getDetailActivity(detailId);

            gridControl1.DataSource = new BindingList<FIDetailActivity>(detailActivity);
        }

        public int detId;
        public List<FIDetailActivity> detailActivity = new List<FIDetailActivity>();

        private void btnMTtoIA_Click(object sender, EventArgs e)
        {
            FIDetailActivity aaa = new FIDetailActivity();
            aaa.DetailId = detId;
            aaa.Activity = "MT Published to IA";
            aaa.CommentRtf = rtbComments.Rtf;
            aaa.CommentText = rtbComments.Text;
            aaa.ToUser = new Users(12); //??????

            FIDetailActivity.Insert(aaa);
        }
    }
}
