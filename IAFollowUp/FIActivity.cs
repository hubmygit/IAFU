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
            detailActivity = FIDetailActivity.Select(detailId);

            gridControl1.DataSource = new BindingList<FIDetailActivity>(detailActivity);
        }

        public int detId;
        public List<FIDetailActivity> detailActivity = new List<FIDetailActivity>();


        private void btnFontDialog_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = true;

            fontDialog1.Font = rtbComments.SelectionFont;
            fontDialog1.Color = rtbComments.SelectionColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                rtbComments.SelectionFont = fontDialog1.Font;
                rtbComments.SelectionColor = fontDialog1.Color;
            }

        }
        
        private void btnMTtoIA_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(2);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id); 
            
            FIDetailActivity.Insert(detActivity);
        }

        private void btnMTtoDT_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(7);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
        }

        private void btnDTtoMT_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(6);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
        }

        private void btnIAtoMT_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(3);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
        }

        private void btnMTtoIAInform_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(4);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);

            FIDetailActivity.Insert(detActivity);
        }

        private void btnMTtoDTDelegate_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(5);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);
            //detActivity.ToUser = TODO ???????????????????????

            FIDetailActivity.Insert(detActivity);
        }

        private void btnMTtoIAExtension_Click(object sender, EventArgs e)
        {
            FIDetailActivity detActivity = new FIDetailActivity();
            detActivity.DetailId = detId;
            detActivity.ActivityDescription = new ActivityDescription(8);
            detActivity.CommentRtf = rtbComments.Rtf;
            detActivity.CommentText = rtbComments.Text;
            detActivity.FromUser = new Users(UserInfo.userDetails.Id);

            FIDetailActivity.Insert(detActivity);
        }
    }
}
