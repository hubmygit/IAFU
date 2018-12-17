using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class EmailProperties
    {
        public List<Recipient> Recipients { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        //public bool ToSend { get; set; }

        public EmailProperties()
        {
        }
    }
}
