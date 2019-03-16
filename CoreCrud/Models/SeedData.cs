using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoreCrud.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // GATTUSMP: SAMPLE OF A SEED FILE THAT FIRST LOOKS FOR A DATABASE WITH DATA
                //           IF NO DATA FOUND THEN DATA IS ADDED TO THE DATABASE
                // // Look for any movies.
                 if (context.Destinations.Any())
                 {
                     return;   // DB has been seeded
                 }

                var USACountry = new Country { Name = "USA" };
                var IndiaCountry = new Country { Name = "India" };
                var CanadaCountry = new Country { Name = "Canada" };
                var ChinaCountry = new Country { Name = "China" }; 

                context.Countries.AddRange(
                    USACountry,
                    IndiaCountry,
                    CanadaCountry,
                    ChinaCountry
                );



                context.Destinations.AddRange(
                    new Destination
                    {
                        Name = "Taj Mahal",
                        CurrentTemp = 45,
                        TypeOfDestination = "Tourist",
                        AverageRainfall = 100.32M,
                        IsSafe = true,
                        DateOfLastRainfall = new DateTime(2018,9,4),
                        Country = IndiaCountry
                    },
                    new Destination
                    {
                        Name = "Statue of Liberty",
                        CurrentTemp = 33,
                        TypeOfDestination = "Tourist",
                        AverageRainfall = 150.81M,
                        IsSafe = true,
                        DateOfLastRainfall = new DateTime(2018,9,2),
                        Country = USACountry
                    }
             

                //  context.Movie.AddRange(
                //     new Movie
                //     {
                //         Title = "When Harry Met Sally",
                //         ReleaseDate = DateTime.Parse("1989-2-12"),
                //         Genre = "Romantic Comedy",
                //         Price = 7.99M
                //     },

                //     new Movie
                //     {
                //         Title = "Ghostbusters",
                //         ReleaseDate = DateTime.Parse("1984-3-13"),
                //         Genre = "Comedy",
                //         Price = 8.99M
                //    },

                //    new Movie
                //     {
                //         Title = "Ghostbusters 2",
                //         ReleaseDate = DateTime.Parse("1986-2-23"),
                //         Genre = "Comedy",
                //         Price = 9.99M
                //
                //     },

                //     new Movie
                //     {
                //         Title = "Rio Bravo",
                //         ReleaseDate = DateTime.Parse("1959-4-15"),
                //         Genre = "Western",
                //         Price = 3.99M
                //     }
                 );
                context.SaveChanges();
            }
        }
    }
}
