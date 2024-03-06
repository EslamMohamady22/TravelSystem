using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace JobOfferWebiste.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
        
        public bool Requested { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}