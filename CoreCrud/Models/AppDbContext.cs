using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<CoreCrud.Models.Destination> Destinations { get; set; }
        public DbSet<CoreCrud.Models.Country> Countries { get; set; }
        public object Destination { get; internal set; }
    }
}
