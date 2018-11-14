using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public int RolesId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime InsDt { get; set; }
        public bool HasActivePassword { get; set; }
    }
}
