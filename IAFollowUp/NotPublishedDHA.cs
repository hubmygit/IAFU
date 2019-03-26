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
    public partial class NotPublishedDHA : Form
    {
        public NotPublishedDHA()
        {
            InitializeComponent();

            detailList = FIDetail.SelectNotPublished(UserInfo.roleDetails.IsAdmin);
            List<FIHeader> headerList = FIHeader.Select(UserInfo.roleDetails.IsAdmin, detailList);
            List<Audit> auditList = Audit.Select(UserInfo.roleDetails.IsAdmin, headerList);
            fiDHABList = FI_DetailHeaderAudit.AuditListToDetailListNotPublished(auditList);

            gridControl1.DataSource = fiDHABList;
        }

        public BindingList<FI_DetailHeaderAudit> fiDHABList = new BindingList<FI_DetailHeaderAudit>();
        public List<FIDetail> detailList = new List<FIDetail>();

    }
}
