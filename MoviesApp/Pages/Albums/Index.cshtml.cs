using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly MoviesApp.Models.AppDbContext _context;

        public IndexModel(MoviesApp.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }

        public async Task OnGetAsync()
        {
            Album = await _context.Albums.ToListAsync();
        }
    }
}
