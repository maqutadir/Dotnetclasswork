using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesApp.Models;

namespace MoviesApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public CreateModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name");
        ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
        ViewData["StudioId"] = new SelectList(_context.Studios, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name");
                ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
                ViewData["StudioId"] = new SelectList(_context.Studios, "Id", "Name");
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}