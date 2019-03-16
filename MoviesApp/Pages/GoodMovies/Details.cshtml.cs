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
    public class DetailsModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public DetailsModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
