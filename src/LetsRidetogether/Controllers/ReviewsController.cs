using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetsRidetogether.Services;
using LetsRidetogether.ViewModels.Manage;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsRidetogether.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private ReviewService _service;
        public ReviewsController(ReviewService service)
        {
            _service = service;
        }

 // GET: api/values
        [HttpGet]
        public IEnumerable<ReviewDTO> Get()
        {
            var reviews = _service.GetReviewByUser(User.Identity.Name);
            return reviews;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("{id}")]
        public void  Post([FromBody]ReviewDTO reviewdto, int id)
        {
             _service.PostReview( reviewdto, User.Identity.Name, id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _service.Delete(id);
        //}
    }
}
