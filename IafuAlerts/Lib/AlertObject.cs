using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IafuAlerts
{
    public class AlertObject
    {
        public int DetailId { get; set; }
        public DateTime? ActionDt { get; set; }
        public Placeholders Placeholder { get; set; }
        public Users User { get; set; }
        public Users Auditor1 { get; set; }
        public bool Auditor1Idle { get; set; }
        public Users Auditor2 { get; set; }
        public bool Auditor2Idle { get; set; }
        public Users Supervisor { get; set; }
        public bool SupervisorIdle { get; set; }

        public AlertObject()
        {

        }
    }
}
