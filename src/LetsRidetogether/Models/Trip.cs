using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsRidetogether.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public decimal Cost { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }



        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
