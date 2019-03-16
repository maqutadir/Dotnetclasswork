using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesApp.Models;

namespace MoviesApp.Pages
{

    public class CreateNewMovieModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateNewMovieModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public NewMyMovie NewMyMovie { get; set; }
        public void OnGet()
        {
            PopulateSelectLists();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                PopulateSelectLists();
                return Page();
            }
            
            var goodmovie = new GoodMovie();
           
            goodmovie.ProducerId = NewMyMovie.ProducerId.Value;
            goodmovie.StudioId = NewMyMovie.StudioId.Value;
            goodmovie.Name = NewMyMovie.Name;
            _context.GoodMovies.Add(goodmovie);
            _context.SaveChanges();
            return RedirectToPage("/goodmovies/details", new { Id = goodmovie.Id });
        }
        
        private void PopulateSelectLists() {
            
            var producers = _context.Producers
                                 .OrderBy(x => x.NoOfMoviesProduced)
                                 .ToList();
            ViewData["ProducerId"] = new SelectList(producers, "Id", "Name");
            
           
            var studios = _context.Studios
                                 .Where(x => x.NoOfMoviesShot > 5)
                                 .OrderBy(x => x.Name)
                                 .ToList();
            ViewData["StudioId"] = new SelectList(studios, "Id", "Name");
            
            

            
            // NOTE WE SET THE ViewData property with the same name as the 
            // property name in our model that will hold the selected value
            
        }
    }
}