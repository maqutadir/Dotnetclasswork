
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class StopPlaying
    {
        // CONSTRUCTOR
        public StopPlaying()
        {
             LastPlayed = DateTime.Today;
        }

        public int MovieId { get; set; }
        
        [Display(Name="Last Played at the theatre")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(StopPlaying), "StopPlayingValidation")]
        public DateTime LastPlayed { get; set; }

        public static ValidationResult StopPlayingValidation(DateTime? lastPLayed , ValidationContext context) {
            if (lastPLayed == null) {
                return ValidationResult.Success;
            }

            var today = DateTime.Today;

            if (lastPLayed < today.AddYears(-10)) {
                return new ValidationResult("You can only assign last day played for movies which had their last day within the last 10 years");
            }

            return ValidationResult.Success;
        }
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
            