using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MoviesApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                 if (context.Movies.Any())
                 {
                     return;   // DB has been seeded
                 }

                var WarnerBrosProducer = new Producer { Name = "Warner Bros.", NoOfMoviesProduced = 350, Isreputed = true };
                var ParamountPicturesProducer = new Producer { Name = "Paramount Pictures", NoOfMoviesProduced = 900, Isreputed = true  };
                var SonyPicturesProducer = new Producer { Name = "Sony Pictures", NoOfMoviesProduced = 299, Isreputed = true  };
                var FoxStarStudioProducer = new Producer { Name = "Fox Star Studio", NoOfMoviesProduced = 321, Isreputed = true  };

                    context.Producers.AddRange(
                    WarnerBrosProducer,
                    ParamountPicturesProducer,
                    SonyPicturesProducer,
                    FoxStarStudioProducer
                    
                );

                var WaltDisneyPicturesStudio = new Studio { Name = "Walt Disney Pictures", Location = "Burbank", FoundedIn = 1923, Area = 190000.46M, NoOfMoviesShot = 700, };

                    context.Studios.AddRange(
                        WaltDisneyPicturesStudio
                    
                );

                var MymusicAlbum = new Album { Name = "Titanic", MusicDirector = "AR Rahman", Length = 200.3M, Featuring = "SRK", Genre = "Bollywood", Artist = "Mohit Chauhan", DateOfRecording = DateTime.Parse("1984-3-13")};

                    context.Albums.AddRange(
                        MymusicAlbum
                    
                );

                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "Incredibles 2",
                        Budget = 300002913,
                        BOCollection = 601022913,
                        Rating = 2,
                        DateofRelease = DateTime.Parse("1984-3-13"),
                        Isrecommended = true,
                        DateLastPlayed = DateTime.Parse("1985-3-13"),
                        Producer = WarnerBrosProducer,
                        Studio = WaltDisneyPicturesStudio,
                        Album = MymusicAlbum

                    }
                );

            

                
                // GATTUSMP: SAMPLE OF A SEED FILE THAT FIRST LOOKS FOR A DATABASE WITH DATA
                //           IF NO DATA FOUND THEN DATA IS ADDED TO THE DATABASE
                // // Look for any movies.
                // if (context.Movie.Any())
                // {
                //     return;   // DB has been seeded
                // }

                // context.Movie.AddRange(
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
                //     },

                //     new Movie
                //     {
                //         Title = "Ghostbusters 2",
                //         ReleaseDate = DateTime.Parse("1986-2-23"),
                //         Genre = "Comedy",
                //         Price = 9.99M
                //     },

                //     new Movie
                //     {
                //         Title = "Rio Bravo",
                //         ReleaseDate = DateTime.Parse("1959-4-15"),
                //         Genre = "Western",
                //         Price = 3.99M
                //     }
                // );
                context.SaveChanges();
            }
        }
    }
}