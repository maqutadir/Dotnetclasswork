
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Producer
    {
        // CONSTRUCTOR
        public Producer()
        {
            
        }

        // PRIMARY KEY - DO NOT REMOVE
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name of the Producer")]
        [Required(ErrorMessage = "Please input the name of the producer")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Name { get; set; }

        [Display(Name = "No. of movies produced")]
        [Required(ErrorMessage = "Please enter the total number of movies produced")]
        [Range(0, 1000, ErrorMessage = "Enter a value between 0-1000")]
        public int NoOfMoviesProduced { get; set; }

        [Display(Name = "Am I reputed?")]
        public bool? Isreputed { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<GoodMovie> GoodMovies { get; set; }

        public bool ReputationUnknown {
            get { return Isreputed == null; }
        }

        // OTHER PROPERTIES GO HERE
    }
}

/* 
    PROPERTY EXAMPLES

    // BASIC STRING PROPERTY
    public string FirstName { get; set; }

    // BASIC INT (number) PROPERTY
    public int Age { get; set; }

    // BASIC NULLABLE INT (number) PROPERTY
    public int? Age { get; set; }

    // BASIC BOOLEAN (true/false) PROPERTY
    public bool AcceptedTermsAndConditions { get; set; }

    // BASIC NULLABLE BOOLEAN (true/false) PROPERTY
    public bool? IsCompleted { get; set; }

    // BASIC DATE TIME PROPERTY
    public datetime Created { get; set; }

    // BASIC NULLABLE DATE TIME PROPERTY
    public datetime? Modified { get; set; }

    -----------------------------------------------------------------

    // RELATIONSHIPS

    //  CHILD / MANY-TO-MANY / MANY SIDE OF ONE-TO-MANY RELATIONSHIP
    public virtual ICollection<Book> Books { get; set; }

    // PARENT / 1-1 / ONE SIDE OF ONE-TO-MANY RELATIONSHIP
    public virtual BookStore BookStore {get; set; }
*/
            