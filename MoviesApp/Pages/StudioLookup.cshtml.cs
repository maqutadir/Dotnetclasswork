using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Pages
{
    public class StudioLookupModel : PageModel
    {
        private AppDbContext _context;
         public StudioLookupModel(AppDbContext context){
              _context = context;
         }
        public void OnGet() => Movies = _context.Movies
                    .Include(mov => mov.Studio)
                    .OrderBy(mov => mov.Id)
                    .ToList();

        public List<Movie> Movies { get; set; }
    }
}