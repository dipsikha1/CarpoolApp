using LetsRidetogether.Data;
using LetsRidetogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Infrastructure
{
    public class ReviewRepository : GenericRepository<Review>
    {
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
        }

        public ICollection<Review> GetReviews()
        {
            return _db.Reviews.ToList();
        }


        public Review GetReviewById(int id)
        {
            return _db.Reviews.FirstOrDefault(r => r.Id == id);
        }
    }
}