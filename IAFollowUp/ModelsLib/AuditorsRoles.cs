using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class AuditorsRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AuditorsRoles()
        {
        }

        public AuditorsRoles(int givenId)
        {
            Id = givenId;

            if (givenId == 1)
            {
                Name = "Auditor1";
            }
            else if (givenId == 2)
            {
                Name = "Auditor2";
            }
            else if (givenId == 3)
            {
                Name = "Supervisor";
            }
            else if (givenId == 4)
            {
                Name = "Chief Audit Executive";
            }
        }
    }
}
