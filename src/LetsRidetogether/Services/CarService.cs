using LetsRidetogether.Infrastructure;
using LetsRidetogether.Models;
using LetsRidetogether.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Services
{
    public class CarService
    {
        private CarRepository _repo;

        public CarService(CarRepository repo)
        {
            _repo = repo;
        }


        public IList<CarDTO> GetCarDTO(int id)
        {
            var car = _repo.List().Where(c => c.Id == id).Select(c => new CarDTO
            {
                Id = c.Id,
                Model = c.Model,
                SeatCapacity = c.SeatCapacity
                

            }).ToList();
            return car;

        }
    


        public CarDTO GetCarById(int id)
        {
            var car = _repo.List().Where(c => c.Id == id).Select(c => new CarDTO
            {
                Id = c.Id,
                Model = c.Model,
                SeatCapacity = c.SeatCapacity
           }).FirstOrDefault();
            return car;


        }

    public void UpdateCar(CarDTO car)
    {
        var orig = _repo.GetCarById(car.Id);
            orig.Model = car.Model;
            orig.SeatCapacity = car.SeatCapacity;
            _repo.SaveChanges();
    }

    public void AddCar(CarDTO cardto)
    {

            var car = new Car
            {
                Model = cardto.Model,
                SeatCapacity = cardto.SeatCapacity
            };

            _repo.Add(car);
            _repo.SaveChanges();
        }


        public void DeleteCar(int id)
    {
        var orig = _repo.GetCarById(id);
        _repo.Delete(orig);
        _repo.SaveChanges();
    }
}
}
