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
    public partial class NotifInactive15Days : Form
    {
        public NotifInactive15Days()
        {
            InitializeComponent();

            List<Notif1Obj> fourthNotifObj = Notifications.fourthNotification();

            gridControl1.DataSource = new BindingList<Notif1Obj>(fourthNotifObj);
        }
    }
}
