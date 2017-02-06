using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LetsRidetogether.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LetsRidetogether.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Review>Reviews {get; set;}


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserTrip>().HasKey(x => new { x.TripId, x.UserId });
            builder.Entity<Car>().HasMany(c => c.Trips).WithOne(x => x.Car).IsRequired();
            builder.Entity<ApplicationUser>().HasMany(u => u.Reviews).WithOne(r => r.User);//.IsRequired().OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ApplicationUser>().HasMany(e => e.Reviews).WithOne(g => g.RatingUser).IsRequired().OnDelete(DeleteBehavior.Restrict);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
