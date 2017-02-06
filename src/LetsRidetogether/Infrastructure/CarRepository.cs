using LetsRidetogether.Data;
using LetsRidetogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Infrastructure
{
    public class CarRepository : GenericRepository<Car>
    {
        public CarRepository(ApplicationDbContext db) : base(db)
        {
        }

        public ICollection<Car> GetCars()
        {
            return _db.Cars.ToList();
        }


        public Car GetCarById(int id)
        {
            return _db.Cars.FirstOrDefault(c => c.Id == id);
        }
    }
}