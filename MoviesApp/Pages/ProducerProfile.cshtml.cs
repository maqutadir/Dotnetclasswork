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
    public class ProducerProfileModel : PageModel
    {

        private AppDbContext _context;

            public ProducerProfileModel(AppDbContext context) {
                _context = context;
            }

            public Producer Producer { get; set; }

           

        public IActionResult OnGet(int? id) 
        {

            if(id == null){
                return NotFound();
            }
            
            Producer = _context.Producers
                              .Include(Pro => Pro.Movies)
                              .FirstOrDefault(Pro => Pro.Id == id);

            

            if (Producer == null){
                return NotFound();
            } 

            return Page();
        }                     
    }
}