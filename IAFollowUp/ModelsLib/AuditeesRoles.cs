using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class AuditeesRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AuditeesRoles()
        {
        }

        public AuditeesRoles(int givenId)
        {
            Id = givenId;

            if (givenId == 1)
            {
                Name = "General Managers";

            }
            else if (givenId == 2)
            {
                Name = "Management Team";
            }
            else if (givenId == 3)
            {
                Name = "Delegatees";
            }
        }

    }
}
