using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int SeatCapacity { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
