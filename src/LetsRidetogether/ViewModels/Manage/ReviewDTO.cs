using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.ViewModels.Manage
{
    public class ReviewDTO
    {
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public string Username { get; set; }
    }
}
