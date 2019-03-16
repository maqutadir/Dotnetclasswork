using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages.GoodMovies
{
    public class DeleteModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public DeleteModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GoodMovie GoodMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GoodMovie = await _context.GoodMovies
                .Include(g => g.Producer)
                .Include(g => g.Studio).FirstOrDefaultAsync(m => m.Id == id);

            if (GoodMovie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GoodMovie = await _context.GoodMovies.FindAsync(id);

            if (GoodMovie != null)
            {
                _context.GoodMovies.Remove(GoodMovie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
