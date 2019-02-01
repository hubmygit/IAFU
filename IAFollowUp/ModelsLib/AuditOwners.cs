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

        public List<Recipient> getRecipients(bool includeSupervisor)
        {
            List<Recipient> ret = new List<Recipient>();

            if (Auditor1.Id > 0)
            {
                Recipient thisRecipient = new Recipient() { FullName = Auditor1.FullName, Email = Auditor1.getEmail() };
                ret.Add(thisRecipient);
            }

            if (Auditor2.Id > 0)
            {
                Recipient thisRecipient = new Recipient() { FullName = Auditor2.FullName, Email = Auditor2.getEmail() };
                ret.Add(thisRecipient);
            }

            if (includeSupervisor == true && Supervisor.Id > 0)
            {
                Recipient thisRecipient = new Recipient() { FullName = Supervisor.FullName, Email = Supervisor.getEmail() };
                ret.Add(thisRecipient);
            }

            //foreach (Users usr in usersList)
            //{
            //    Recipient thisRecipient = new Recipient() { FullName = usr.FullName, Email = usr.getEmail() };
            //    if (distinctRecipients.Exists(i => i.Email == thisRecipient.Email) == false || distinctRecipients.Exists(i => i.FullName == thisRecipient.FullName) == false)
            //    {
            //        distinctRecipients.Add(thisRecipient);
            //    }
            //}



            return ret;
        }
    }
}
