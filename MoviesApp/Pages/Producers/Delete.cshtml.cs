using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages.Producers
{
    public class DeleteModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public DeleteModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producer Producer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producer = await _context.Producers.FirstOrDefaultAsync(m => m.Id == id);

            if (Producer == null)
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

            Producer = await _context.Producers.FindAsync(id);

            if (Producer != null)
            {
                _context.Producers.Remove(Producer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
