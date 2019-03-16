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
    public class IndexModel : PageModel
    {

        private AppDbContext _context;
        public IndexModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet() {
            CountOfCountries = _context.Countries
                                    .Count();

            CountOfDestinations = _context.Destinations
                                    .Count();

            CountOfSafe = _context.Destinations
                                    .Where(x => x.IsSafe == true)
                                    .Count();

            CountOfAvgRain = _context.Destinations
                                    .Where(x => x.AverageRainfall > 130)
                                    .Count();


            CountOfCurrentTemp = _context.Destinations
                                     .Where(x => x.CurrentTemp < 50)
                                     .Count();
        }
            public int CountOfCountries { get; set; }
            public int CountOfDestinations { get; set; }
            public int CountOfSafe { get; set; }
            public int CountOfAvgRain { get; set; }
            public int CountOfCurrentTemp { get; set; }
                    
    }
}