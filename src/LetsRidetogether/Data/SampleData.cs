using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using LetsRidetogether.Models;

namespace LetsRidetogether.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Dipsi (IsAdmin)
            var dipsi = await userManager.FindByNameAsync("Dipsi@gmail.com");
            if (dipsi == null)
            {
                dipsi = new ApplicationUser
                {
                    Name = "Dipsi",
                    UserName = "Dipsi@gmail.com",
                    Email = "Dipsi@gmail.com",
                    Contact = "2142245678",
                    Rating = 5,
                    Location = "Houston"

                };
                await userManager.CreateAsync(dipsi, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(dipsi, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@gmail.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@gmail.com",
                    Email = "Mike@gmail.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            if (!context.Cars.Any())
            {

                context.Cars.AddRange(
                                new Car
                                {
                                    Model = "Infiniti Q40",
                                    SeatCapacity = 5

                                }
                                );

                context.SaveChanges();


                if (!context.Trips.Any())
                {

                    context.Trips.AddRange(
                    new Trip
                    {
                        CarId = context.Cars.FirstOrDefault(c => c.Model == "Infiniti Q40").Id,
                        StartAddress = "Katy Mill Mall, 77494",
                        EndAddress = "University of Houston, 77004",
                        DatePosted = System.DateTime.Now,
                        Cost = 20

                    }
                   );
                    context.SaveChanges();

                    if (!context.UserTrips.Any())
                    {

                        context.UserTrips.AddRange(
                            new UserTrip
                            {
                                UserId = context.Users.FirstOrDefault(u => u.UserName == "Dipsi@gmail.com").Id,

                                TripId = context.Trips.FirstOrDefault(t => t.StartAddress == "Katy Mill Mall, 77494").Id
                            }
                            );
                        context.SaveChanges();
                    }

                }

            }
        }
    }
}
