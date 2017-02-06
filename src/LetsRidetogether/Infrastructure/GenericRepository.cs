using LetsRidetogether.Data;
using LetsRidetogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRidetogether.Infrastructure
{
 
        public class GenericRepository<T> : IDisposable where T : class
        {
            protected ApplicationDbContext _db;
            public GenericRepository(ApplicationDbContext db)
            {
                _db = db;
            }
            public IQueryable<T> List()
            {
                return _db.Set<T>();
            }
            public void Add(T entity)
            {
                _db.Set<T>().Add(entity);
            }
            public void Delete(T entity)
            {
                _db.Set<T>().Remove(entity);
            }
            public void SaveChanges()
            {
                _db.SaveChanges();
            }
            public void Dispose()
            {
                _db.Dispose();
            }
        public ApplicationUser GetUserByUserName(string UserName)
        {
            return _db.Users.FirstOrDefault( u => u.UserName == UserName);
        }
        public void AddUserTrip(UserTrip usertrip)
        {
            _db.UserTrips.Add(usertrip);
        }

        public IQueryable<T> FindBy(string startAddress, string endAddress) {

            return _db.Set<T>();
        }

        }
    }



