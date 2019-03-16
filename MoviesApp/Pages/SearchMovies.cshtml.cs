using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages
{
    public class SearchMoviesModel : PageModel
    {
        
        private AppDbContext _context;
        
        public SearchMoviesModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet()
        {
            SearchFinished = false;
        }

        [BindProperty]
        public string Search { get; set; }
        public bool SearchFinished { get; set; }
        public ICollection<Movie> SearchResults { get; set; }

        public void OnPost() {
            
            if (string.IsNullOrWhiteSpace(Search)) {
                return;
            }
            SearchResults = _context.Movies
                                    .Include(mov => mov.Studio)
                                    .Include(mov => mov.Album)
                                    .Where(mov => mov.Name.ToLower().Contains(Search.ToLower()))
                                    .ToList();
            SearchFinished = true;
        }

    }
}