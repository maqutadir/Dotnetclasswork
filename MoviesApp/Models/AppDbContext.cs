using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }

        public DbSet<MoviesApp.Models.Movie> Movies { get; set; }
        public DbSet<MoviesApp.Models.Producer> Producers { get; set; }
        public DbSet<MoviesApp.Models.Studio> Studios { get; set; }
        public DbSet<MoviesApp.Models.Album> Albums { get; set; }
        public DbSet<MoviesApp.Models.GoodMovie> GoodMovies { get; set; }
    }
}