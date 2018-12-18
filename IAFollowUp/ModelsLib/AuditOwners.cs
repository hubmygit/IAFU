using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class AuditOwners
    {
        public Users Auditor1 { get; set; }
        public Users Auditor2 { get; set; }
        public Users Supervisor { get; set; }

        public AuditOwners()
        {
        }

        public AuditOwners(Users auditor1, Users auditor2, Users supervisor)
        {
            Auditor1 = auditor1;
            Auditor2 = auditor2;
            Supervisor = supervisor;
        }

        public bool IsUser_AuditOwner()
        {
            bool ret = false;

            if (UserInfo.userDetails.Id == Auditor1.Id || UserInfo.userDetails.Id == Auditor2.Id || UserInfo.userDetails.Id == Supervisor.Id)
            {
                ret = true;
            }
            
            return ret;
        }
    }
}
