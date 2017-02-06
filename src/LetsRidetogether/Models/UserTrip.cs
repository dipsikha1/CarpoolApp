using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Models
{
    public class UserTrip

    {
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [ForeignKey("TripId")]
        public Trip Trip { get; set; }
        public int TripId { get; set; }
    }
}
