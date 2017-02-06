using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetsRidetogether.Services;
using LetsRidetogether.Models;
using LetsRidetogether.ViewModels;
using LetsRidetogether.Infrastructure;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsRidetogether.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private TripService _service;
        public TripsController(TripService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TripDTO> Get()
        {
            var trips = _service.GetTripDTO();
            return trips;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TripDTO Get(int id)
        {
            return _service.GetTripById(id);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public void Post([FromBody]TripDTO value)
        {
            _service.AddTrip(value, User.Identity.Name);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody]TripDTO value)
        {
            var claims = User.Claims;
            if (value.UserTripDTO.First().UserName == User.Identity.Name || User.HasClaim("IsAdmin", "true"))
                _service.UpdateTrip(value);
        }

        [HttpPost("search")]
        public string Search(string searchString, bool notUsed)
        {
            return "From [HttpPost]Search: filter on " + searchString;

        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {

            _service.DeleteTrip(id);
        }
        [HttpPost("{id}")]
        public void Post(int id, [FromBody]Car car)
        {

            _service.AddCar(id, car);
        }


    }

}
