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
    public class MyMoviesModel : PageModel
    {
        private AppDbContext _context;

        public MyMoviesModel(AppDbContext context) {
            _context = context;
        }

        public Movie Movie { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = _context.Movies
                                    .Include(mov => mov.Album)
                                    .Include(mov => mov.Studio)
                                    .FirstOrDefault(mov => mov.Id == id);


            if (Movie == null) {
                return NotFound();
            }

            return Page();
        }
    }
}