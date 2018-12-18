using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class FIDetailOwners
    {
        public List<Users> UsersList { get; set; }

        public FIDetailOwners()
        {

        }

        public FIDetailOwners(List<Users> usersList)
        {
            UsersList = usersList;
        }

        public bool IsUser_DetailOwner()
        {
            bool ret = false;

            //if (UserInfo.userDetails.Id == Auditor1.Id || UserInfo.userDetails.Id == Auditor2.Id || UserInfo.userDetails.Id == Supervisor.Id)
            if (UsersList.Exists(i => i.Id == UserInfo.userDetails.Id))
            {
                ret = true;
            }

            return ret;
        }
    }
}
