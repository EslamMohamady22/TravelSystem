using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace JobOfferWebiste.Models
{
    public class AplaForJob
    {
        public int Id { get; set; }
       
       


       
        public string commentMassage { get; set; }
        public string AgencycommentMassage { get; set; }

        public DateTime commentDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }
        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}