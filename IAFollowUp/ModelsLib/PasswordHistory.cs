using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class PasswordHistory
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        //public string Password { get; set; }
        public byte[] Pass { get; set; }
        public DateTime PassUpdDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
