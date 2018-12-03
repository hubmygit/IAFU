using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAFollowUp
{
    public class FIHeader
    {
        public int Id { get; set; }
        public int AuditId { get; set; } //?????????
        public string Title { get; set; }
        //public int FICategoryId { get; set; } //?????????
        public FICategory FICategory { get; set; }
        //public int InsUserId { get; set; }
        //public Users InsUser { get; set; }
        //public DateTime InsDt { get; set; }
        //public int UpdUserId { get; set; }
        //public Users UpdUser { get; set; }
        //public DateTime UpdDt { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsPublished { get; set; } //?????????

        public FIHeader()
        {
        }

        /*
        public static bool isEqual(FIHeader x, FIHeader y)
        {
            if (x.Id == y.Id && x.AuditId == y.AuditId && x.Title == y.Title && x.FICategoryId == y.FICategoryId && FICategory.isEqual(x.FICategory, y.FICategory))
                return true;
            else
                return false;
        }
        */
    }
}
