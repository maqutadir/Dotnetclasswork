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
    public class DeleteModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public DeleteModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Studio = await _context.Studios.FindAsync(id);

            if (Studio != null)
            {
                _context.Studios.Remove(Studio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
