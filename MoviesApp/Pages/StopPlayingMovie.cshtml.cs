using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesApp.Models;

namespace MoviesApp.Pages
{
    public class StopPlayingMovieModel : PageModel
    {
        private readonly AppDbContext _context;

        public StopPlayingMovieModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StopPlaying StopPlaying { get; set; }

        public Movie Movie { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            Movie = _context.Movies.Find(id);

            if (Movie == null) {
                return NotFound();
            }

            
            StopPlaying = new StopPlaying();
            StopPlaying.MovieId = Movie.Id;
            return Page();
        }

        public IActionResult OnPost() {

            Movie = _context.Movies.Find(StopPlaying.MovieId);

            if (!ModelState.IsValid) {
            
                 return Page();
            }
            
            // UPDATE THE AGENT RETRIEVED FROM THE DATABASE
            Movie.DateLastPlayed = StopPlaying.LastPlayed;
            

            // TELL THE DATABASE TO SAVE WHATEVER CHANGES WE MADE
            _context.SaveChanges();
            return RedirectToPage("/StopPlayingMovie", new  { id = Movie.Id });
        }
    }
}