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

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            //send email(s)....
            if (Email.SendBcc(thisEmailList))
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
