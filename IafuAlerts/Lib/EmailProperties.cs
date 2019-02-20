using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IafuAlerts
{
    public class EmailProperties
    {
        public List<Recipient> RecipientsTo { get; set; }
        public List<Recipient> RecipientsCC { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        //public bool ToSend { get; set; }

        public EmailProperties()
        {
        }
    }
}
