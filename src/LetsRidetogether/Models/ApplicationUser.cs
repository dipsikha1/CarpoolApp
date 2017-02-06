using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsRidetogether.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Location { get; set; } // user location
        public string Contact { get; set; }
        public decimal Rating { get; set; }
        public ICollection<UserTrip> UserTrips { get; set; }
        //[InverseProperty("User") ]
        public ICollection<Review> Reviews { get; set; }
    }
}




