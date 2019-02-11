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
    public partial class NotifWillExpireThisMonth : Form
    {
        public NotifWillExpireThisMonth()
        {
            InitializeComponent();

            List<Notif1Obj> firstNotifObj = Notifications.firstNotification();

            gridControl1.DataSource = new BindingList<Notif1Obj>(firstNotifObj);
        }
    }
}
