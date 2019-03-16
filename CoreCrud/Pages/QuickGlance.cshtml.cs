using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class QuickGlanceModel : PageModel
    {
        private AppDbContext _context;
         public QuickGlanceModel(AppDbContext context){
              _context = context;
         }
        public void OnGet() => Destinations = _context.Destinations
                .Include(des => des.Country)
                .OrderBy(des => des.Id)
                .ToList();

        public List<Destination> Destinations { get; set; }
    }
}