using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Models;

namespace MoviesApp.Pages
{
    public class IndexModel : PageModel
    {
        private AppDbContext _context;
        public IndexModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet()
        {
            CountOfProducers = _context.Producers
                                    .Count();

            CountOfStudios = _context.Studios
                                    .Count();

            CountOfMovies = _context.Movies
                                    .Count();

            CountOfAlbums = _context.Albums
                                    .Count();

            CountOfGoodMovies = _context.GoodMovies
                                    .Count();
            ReputedProducers = _context.Producers
                                    .Where(x => x.Isreputed == true)
                                    .Count();
        }                            

            public int CountOfProducers { get; set; }
            public int CountOfStudios { get; set; }
            public int CountOfMovies { get; set; }
            public int CountOfAlbums { get; set; }
            public int CountOfGoodMovies { get; set; }
            public int ReputedProducers { get; set; }
                        
                        




        }
    
}
