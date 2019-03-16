using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages.Studios
{
    public class EditModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public EditModel(MoviesApp.Models.AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Studio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(Studio.Id))
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

        private bool StudioExists(int id)
        {
            return _context.Studios.Any(e => e.Id == id);
        }
    }
}
