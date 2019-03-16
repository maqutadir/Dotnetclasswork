using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public EditModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies
                .Include(m => m.Album)
                .Include(m => m.Producer)
                .Include(m => m.Studio).FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
           ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name");
           ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
           ViewData["StudioId"] = new SelectList(_context.Studios, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name");
                ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
                ViewData["StudioId"] = new SelectList(_context.Studios, "Id", "Name");
                return Page();
            }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
