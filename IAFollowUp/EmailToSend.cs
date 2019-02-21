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
    public partial class EmailToSend : Form
    {
        public EmailToSend()
        {
            InitializeComponent();
        }
        public EmailToSend(EmailProperties emailList)
        {
            InitializeComponent();

            thisEmailList = emailList;

            txtSubject.Text = emailList.Subject;
            txtBody.Text = emailList.Body;

            gridControl1.DataSource = new BindingList<Recipient>(emailList.Recipients);
        }

        private EmailProperties thisEmailList = new EmailProperties();
        private bool bwSuccess = false;

        private void btnSendMail_Click(object sender, EventArgs e)
        {            
            marqueeProgressBarControl1.Visible = true;
            marqueeProgressBarControl1.Properties.Stopped = false;
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerAsync();
            bw.DoWork += (sender2, e2) =>
            {
                bwSuccess = Email.SendBcc(thisEmailList);

                bw.ReportProgress(100);
            };


            ////send email(s)....
            //if (Email.SendBcc(thisEmailList))
            //{
            //    MessageBox.Show("Email(s) sent!");
            //}
            //else
            //{
            //    MessageBox.Show("Emails have not been sent!");
            //}

            //Close();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            marqueeProgressBarControl1.Properties.Stopped = true;
            marqueeProgressBarControl1.Visible = false;

            if (bwSuccess)
            {
                MessageBox.Show("Email(s) sent!");
            }
            else
            {
                MessageBox.Show("Emails have not been sent!");
            }

            Close();
        }
    }
}
