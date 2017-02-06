using LetsRidetogether.Infrastructure;
using LetsRidetogether.Models;
using LetsRidetogether.ViewModels.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Services
{
    public class ReviewService
    {
        private ReviewRepository _repo;
        private TripRepository _tripRepo;
        public ReviewService(ReviewRepository repo, TripRepository tripRepo)
        {
            _repo = repo;
            _tripRepo = tripRepo;
            
        }


        public IList<ReviewDTO> GetReviewByUser(string username )
        {
            var user = _repo.GetUserByUserName(username);
            return _repo.List().Where(r => r.UserId == user.Id).Select(r => new ReviewDTO
            {

                Rating = r.Rating,
                Comment = r.Comment,
                Username = r.Username
            }).ToList();
        }


        public void PostReview(ReviewDTO reviewdto, string username, int Id)
        {
            var reviewedUserId = (from t in _tripRepo.List()
                                  where t.Id == Id
                                  from u in t.UserTrips select u).FirstOrDefault().UserId;
            var blah = reviewedUserId;
            var reviews = _repo.List().Where(r => r.User.Id == reviewedUserId).Select(r => r);
            var review = new Review
            {
                Rating = (reviews.Sum(x => x.Rating) + reviewdto.Rating) / (reviews.Count() + 1),
                Comment = reviewdto.Comment,
                //Username = reviewdto.Username,
                UserId = reviewedUserId
            };
            _repo.Add(review);
            _repo.SaveChanges();


        }
    }

}


           
