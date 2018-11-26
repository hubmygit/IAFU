using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class Audit
    {
        public int Id { get; set; }
        public int Year { get; set; }
        //public int CompanyId { get; set; } //?????????????????????
        public Companies Company { get; set; }
        //public int AuditTypeId { get; set; } //?????????????????????
        public AuditTypes AuditType { get; set; }
        public string Title { get; set; }
        public DateTime ReportDt { get; set; }
        public int Auditor1ID { get; set; }
        public Users Auditor1 { get; set; }
        public int? Auditor2ID { get; set; }
        public Users Auditor2 { get; set; }
        public int? SupervisorID { get; set; }
        public Users Supervisor { get; set; }
        public bool IsCompleted { get; set; } //?????????????????????
        public string AuditNumber { get; set; }
        public string IASentNumber { get; set; }
        public int AttCnt { get; set; } //?????????????????????

        //public int? AuditRatingId { get; set; } //?????????????????????
        public AuditRating AuditRating { get; set; }

        public bool IsDeleted { get; set; }

        /*
        public static bool isEqual(Audit x, Audit y)
        {
            if (x.Id == y.Id && x.Year == y.Year && x.CompanyId == y.CompanyId && Companies.isEqual(x.Company, y.Company) && x.AuditTypeId == y.AuditTypeId && AuditTypes.isEqual(x.AuditType, y.AuditType) &&
                x.Title == y.Title && x.ReportDt == y.ReportDt && x.Auditor1ID == y.Auditor1ID && Users.isEqual(x.Auditor1, y.Auditor1) && x.Auditor2ID == y.Auditor2ID && Users.isEqual(x.Auditor2, y.Auditor2) &&
                x.SupervisorID == y.SupervisorID && Users.isEqual(x.Supervisor, y.Supervisor) && x.IsCompleted == y.IsCompleted && x.AuditNumber == y.AuditNumber && x.IASentNumber == y.IASentNumber && x.RevNo == y.RevNo &&
                x.AuditRatingId == y.AuditRatingId && AuditRating.isEqual(x.AuditRating, y.AuditRating))
                return true;
            else
                return false;
        }
        */
    }
}
