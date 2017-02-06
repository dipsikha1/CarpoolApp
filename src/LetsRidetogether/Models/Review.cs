using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //public string RatingUserId { get; set; }
        //[ForeignKey("RatingUserId")]
        //public ApplicationUser RatingUser { get; set; }

        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public string Username { get; set; }

    }
}
