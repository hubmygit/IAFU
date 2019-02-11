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
    public partial class NotifWillExpireIn15Days : Form
    {
        public NotifWillExpireIn15Days()
        {
            InitializeComponent();

            List<Notif1Obj> thirdNotifObj = Notifications.thirdNotification();

            gridControl1.DataSource = new BindingList<Notif1Obj>(thirdNotifObj);
        }
    }
}
