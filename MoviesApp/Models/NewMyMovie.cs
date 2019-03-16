
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class NewMyMovie
    {
        
 
        [Display(Name="Producer")]
        [Required(ErrorMessage = "Please select a Producer")]
        [CustomValidation(typeof(NewMyMovie), "ValidateProducerReputation")]
        public int? ProducerId { get; set; }


        [Display(Name="Studio")]
        [Required(ErrorMessage = "Please select a Studio")]
        [CustomValidation(typeof(NewMyMovie), "ValidateStudio")]
        public int? StudioId { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage = "Please enter the name of the movie")]
        public string Name { get; set; }

        

          public static ValidationResult ValidateProducerReputation(int? producerId, ValidationContext context) {
            if (producerId == null) {
                return ValidationResult.Success;
            }

            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;

            var producer = dbContext.Producers.FirstOrDefault(x => x.Id == producerId.Value);

            if (producer == null) {
                return new ValidationResult("Please select a producer");
            }

            if (producer.NoOfMoviesProduced <= 10) {
                return new ValidationResult("This producer is a beginner");
            }
            else if(producer.NoOfMoviesProduced > 10 && producer.NoOfMoviesProduced <= 100){
                return new ValidationResult("This producer is moderately experienced");
            }

            return ValidationResult.Success;
        }
         public static ValidationResult ValidateStudio(int? studioId, ValidationContext context) {
            if (studioId == null) {
                return ValidationResult.Success;
            }

            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;

            var studio = dbContext.Studios.FirstOrDefault(x => x.Id == studioId.Value);

            if (studio == null) {
                return new ValidationResult("Please select a studio");
            }

            if (studio.NoOfMoviesShot <= 10) {
                return new ValidationResult("This studio is a new");
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
            