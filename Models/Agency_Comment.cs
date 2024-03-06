using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace JobOfferWebiste.Models
{
    public class Agency_Comment
    {
        public int AgencycommentId { get; set; }
        public string AgencycommentMassage { get; set; }
        public DateTime AgencycommentDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }
        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}