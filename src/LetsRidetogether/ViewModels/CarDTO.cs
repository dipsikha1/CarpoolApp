using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.ViewModels
{
    public class CarDTO
    {
        //car prop
        public int Id { get; set; }
        public string Model { get; set; }
        public int SeatCapacity { get; set; }

        public ICollection<TripDTO> Trips { get; set; }
    }
}