using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace JobOfferWebiste.Models
{
    public class Job
    {
        public int Id { get; set; }

        
        [Required]
        [DisplayName("Trip Title")]
        public string TripTitle { get; set; }

        [Required]
        [DisplayName("Trip Details")]
        [AllowHtml]
        public string TripDetails { get; set; }
        
       


        [Required]
        [DisplayName("Types of Trips")]
        public int CategoryId { get; set; }


        [Required]
        [DisplayName("Agency Name")]
        [AllowHtml]
        public string AgencyName { get; set; }


        public DateTime PostDate { get; set; }

        [Required]
        [DisplayName("Trip Date")]
        public string TripDate { get; set; }

        [Required]
        [DisplayName("Trip Destination")]
        public string TripDestination { get; set; }

        
        [DisplayName("Trip Image")]
        public string TripImage { get; set; }

        public string Price { get; set; }
        public string UserID { get; set; }
        
        public virtual Category Category { get; set; }
        
        public virtual ApplicationUser User { get; set; }
    }
}