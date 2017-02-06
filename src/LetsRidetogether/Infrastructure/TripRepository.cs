using LetsRidetogether.Data;
using LetsRidetogether.Models;
using LetsRidetogether.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Infrastructure
{
    public class TripRepository : GenericRepository<Trip>
    {
        public TripRepository(ApplicationDbContext db) : base(db) { }

        public ICollection<Trip> GetTrips()
        {
            return _db.Trips.ToList();
        }


        public Trip GetTripById(int id)
        {
            return _db.Trips.FirstOrDefault(t => t.Id == id);
        }
    }
}