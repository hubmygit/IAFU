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
        public EmailToSend(List<EmailProperties> emailList)
        {
            InitializeComponent();
            
            gridControl1.DataSource = new BindingList<EmailProperties>(emailList);
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            //send email(s)....

            MessageBox.Show("Email(s) sent!");
            Close();
        }
    }
}
