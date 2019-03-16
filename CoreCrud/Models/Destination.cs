using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    public class Destination
    {
        // CONSTRUCTOR
        public Destination()
        {
            
        }

        // PRIMARY KEY - DO NOT REMOVE
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name of the destination")]
        [Required(ErrorMessage = "Please input the name of the destination")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]  
        public string Name { get; set; }
        
        [Display(Name = "The Current Temperature")]
        [Required(ErrorMessage = "Please input the current Temperature")]
        [Range(25, 110, ErrorMessage = "Enter a value between 25-110")]
        public int CurrentTemp { get; set; }

        [Display(Name = "Type of the destination")]
        [Required(ErrorMessage = "Please enter the type of the destination")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Please enter between 3 and 15 characters")]
        public string TypeOfDestination { get; set; }
         
        [Display(Name = "Average Rainfall")]
        [Required(ErrorMessage = "Average Amount of Rainfall Received")]
        [CustomValidation(typeof(Destination), "IsTheAverageRainfallRight")]
        public decimal? AverageRainfall { get; set; }
        
        [Display(Name = "Is the Destination safe? True | False")]
        public bool IsSafe { get; set; }

        [Display(Name = "Date of last rainfall")]
        [Required(ErrorMessage = "Please enter the date of last rainfall")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Destination), "Whendiditlastrain")]
        public DateTime DateOfLastRainfall { get; set;}
        
        [Display(Name = "Country Name")]
        public int CountryId { get; set;}
        public Country Country{ get; set;}

        public static ValidationResult Whendiditlastrain(DateTime? DateOfLastRainfall, ValidationContext context) {
            if (DateOfLastRainfall == null) {
                return ValidationResult.Success;
            }
            if (DateOfLastRainfall < DateTime.Today) {
                return ValidationResult.Success;
            }
                return new ValidationResult("Date of last rainfall must be less than the current Date");
        }

        public static ValidationResult IsTheAverageRainfallRight(decimal? AverageRainfall, ValidationContext context) {
            if(AverageRainfall == null){
                return ValidationResult.Success;
            }
            if (AverageRainfall > 50 & AverageRainfall < 200){
                return ValidationResult.Success;
            }
            return new ValidationResult("Averagerainfall must be > 50 and < 200");
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
            

