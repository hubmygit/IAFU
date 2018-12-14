using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class EmailProperties
    {
        public string RecipientFullName { get; set; }
        public string RecipientEmail { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        //public bool ToSend { get; set; }

        public EmailProperties()
        {
        }
    }
}
