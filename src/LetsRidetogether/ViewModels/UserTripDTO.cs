using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.ViewModels
{
    public class UserTripDTO
    {
        public string Name { get; set; }
        public string Location { get; set; } // user location
        public string Contact { get; set; }
        public decimal Rating { get; set; }

        public string UserName { get; set; }
    }

}
