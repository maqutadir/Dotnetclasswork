using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages.Studios
{
    public class DetailsModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public DetailsModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        public Studio Studio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Studio = await _context.Studios.FirstOrDefaultAsync(m => m.Id == id);

            if (Studio == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
