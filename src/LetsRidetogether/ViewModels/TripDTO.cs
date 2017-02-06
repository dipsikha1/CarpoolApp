using LetsRidetogether.ViewModels.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsRidetogether.ViewModels
{
    public class TripDTO
    {
        public int Id { get; set; }
       
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public decimal Cost { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }


        public CarDTO Car { get; set; }


        public ICollection<ReviewDTO> ReviewDTO { get; set; }

        
        public ICollection<UserTripDTO> UserTripDTO { get; set; }
    }
}
