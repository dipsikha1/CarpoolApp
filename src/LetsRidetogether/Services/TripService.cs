using LetsRidetogether.Infrastructure;
using LetsRidetogether.Models;
using LetsRidetogether.ViewModels;
using LetsRidetogether.ViewModels.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Services
{
    public class TripService
    {
        private CarRepository _carRepo;
        private TripRepository _repo;
        private ReviewRepository _reviewRepo;
        public TripService(TripRepository repo, CarRepository carRepo, ReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
            _repo = repo;
            _carRepo = carRepo;
        }

        public IList<TripDTO> GetTripDTO()
        {
            return (from t in _repo.List()
                    select new TripDTO
                    {
                        Id = t.Id,
                        StartAddress = t.StartAddress,
                        EndAddress = t.EndAddress,
                        Cost = t.Cost,
                        DatePosted = System.DateTime.Now,
                        Car = new CarDTO()
                        {
                            Id = t.Car.Id,
                            Model = t.Car.Model,
                            SeatCapacity = t.Car.SeatCapacity

                        },
                        UserTripDTO = (from u in t.UserTrips select new UserTripDTO
                        {
                            Name = u.User.Name,
                            Location = u.User.Location,
                            Rating = u.User.Rating,
                            Contact = u.User.Contact,
                            UserName = u.User.UserName
                        }).ToList()

                    }).ToList();
        }

  
 public TripDTO GetTripById(int Id)
        {
            var trip = _repo.List().Where(t => t.Id == Id).Select(t => new TripDTO
            {

                StartAddress = t.StartAddress,
                EndAddress = t.EndAddress,
                Cost = t.Cost,
                Id = t.Id,
                DatePosted = System.DateTime.Now,
                Car = new CarDTO()
                {
                    Id = t.Car.Id,
                    Model = t.Car.Model,
                    SeatCapacity = t.Car.SeatCapacity
                },
                UserTripDTO = (from u in t.UserTrips
                               select new UserTripDTO
                               {
                                   Name = u.User.Name,
                                   Location = u.User.Location,
                                   Rating = u.User.Rating,
                                   Contact = u.User.Contact,
                                   UserName = u.User.UserName
                               }).ToList(),

                ReviewDTO = (from r in _reviewRepo.List()
                             from ut in t.UserTrips
                             where r.UserId == ut.UserId
                             select new ReviewDTO
                             {
                                 Comment = r.Comment,
                                 Rating = r.Rating,
                                 Username = r.Username
                             }).ToList()
            }).FirstOrDefault();

            return trip;
        }

        public void UpdateTrip(TripDTO trip)
        {
            var orig = _repo.GetTripById(trip.Id);
            var car = (from c in _carRepo.List()
                       where c.Id == orig.CarId
                       select c).FirstOrDefault();
            car.SeatCapacity = trip.Car.SeatCapacity;
            car.Model = trip.Car.Model;
            orig.StartAddress = trip.StartAddress;
            orig.EndAddress = trip.EndAddress;
            orig.DatePosted = System.DateTime.Now;
            orig.Cost = trip.Cost;
            _repo.SaveChanges();
        }

        public void AddTrip(TripDTO tripdto,  string username)
        {

            var user = _repo.GetUserByUserName(username);
            
            var trip = new Trip
            {
                Car = new Car
                {
                    Model = tripdto.Car.Model,
                    SeatCapacity = tripdto.Car.SeatCapacity
                },
                DatePosted = System.DateTime.Now,
                StartAddress = tripdto.StartAddress,
                EndAddress = tripdto.EndAddress,
                Cost = tripdto.Cost
            };

            _repo.Add(trip);
            _repo.SaveChanges();
            _repo.AddUserTrip(new UserTrip { UserId = user.Id, TripId = trip.Id });
            _repo.SaveChanges();
        }

      

        public void DeleteTrip(int id)
        {
            var orig = _repo.GetTripById(id);
            _repo.Delete(orig);
            _repo.SaveChanges();
        }

        public void AddCar(int id, Car car)
        {

            var orig = _repo.GetTripById(id);
            _repo.Add(orig);
            _repo.SaveChanges();


        }
       


    }

    }



  





