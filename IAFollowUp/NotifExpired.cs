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
    public partial class NotifExpired : Form
    {
        public NotifExpired()
        {
            InitializeComponent();

            List<Notif1Obj> secondNotifObj = Notifications.secondNotification();

            gridControl1.DataSource = new BindingList<Notif1Obj>(secondNotifObj);
        }
    }
}
