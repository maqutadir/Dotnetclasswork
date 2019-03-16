
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Studio
    {
        // CONSTRUCTOR
        public Studio()
        {
            
        }

        // PRIMARY KEY - DO NOT REMOVE
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name of the Studio")]
        [Required(ErrorMessage = "Please input the name of the studio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Where is it located?")]
        [Required(ErrorMessage = "Please enter the city where it is located")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Location { get; set; }

        [Display(Name = "Founded In")]
        [Required(ErrorMessage = "When was the studio founded?")]
        [CustomValidation(typeof(Studio), "FoundedInVal")]
        public int FoundedIn { get; set; }

        [Display(Name = "Area in sq. Acres")]
        [Required(ErrorMessage = "Please enter the total area of the studio")]
        [Range(0, 10000, ErrorMessage = "Enter a value between 0-10000")]
        public decimal Area { get; set; }

        [Display(Name = "No. of movies shot here")]
        [Required(ErrorMessage = "Please enter the total number of movies shot here")]
        [Range(0, 5000, ErrorMessage = "Enter a value between 0-5000")]
        public int NoOfMoviesShot { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<GoodMovie> GoodMovies { get; set; }

        
        public static ValidationResult FoundedInVal(int? FoundedIn, ValidationContext context) {
            if (FoundedIn == null) {
                return ValidationResult.Success;
            }

            DateTime today = DateTime.Today;
            string yy = today.Year.ToString();
            int yyint = Int32.Parse(yy);
            if (FoundedIn <= yyint) {
                return ValidationResult.Success;
            }

            string errorMessage = $"Studio must be founded on or before the year { DateTime.Today.Year.ToString() }";
            return new ValidationResult(errorMessage);
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
            