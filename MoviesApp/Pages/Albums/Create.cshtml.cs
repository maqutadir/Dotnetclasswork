using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesApp.Models;

namespace MoviesApp.Pages.Albums
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
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Albums.Add(Album);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}