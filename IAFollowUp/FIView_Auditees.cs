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
    public partial class FIView_Auditees : Form
    {
        public FIView_Auditees()
        {
            InitializeComponent();

            List<FIDetail> detailList = FIDetail.Select(UserInfo.roleDetails.IsAdmin);
            List<FIHeader> headerList = FIHeader.Select(UserInfo.roleDetails.IsAdmin, detailList);
            List<Audit> auditList = Audit.Select(UserInfo.roleDetails.IsAdmin, headerList);

            auditBList = new BindingList<Audit>(auditList);
        }

        public BindingList<Audit> auditBList = new BindingList<Audit>();

    }
}
