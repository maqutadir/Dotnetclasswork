
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Album
    {
        // CONSTRUCTOR
        public Album()
        {
            
        }

        // PRIMARY KEY - DO NOT REMOVE
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name of the soundtrack")]
        [Required(ErrorMessage = "Please input the name of the soundtrack")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Name of the music director")]
        [Required(ErrorMessage = "Please input the name of the music director")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string MusicDirector { get; set; }

        [Display(Name = "Length of the soundtrack in mins")]
        [Required(ErrorMessage = "Please enter the length of the recording")]
        [Range(0, 500, ErrorMessage = "Enter a value between 0-500")]
        public decimal Length { get; set; }

        [Display(Name = "Name of the artist featuring")]
        [Required(ErrorMessage = "Please input the name of the artist featuring")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Featuring { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Enter the Genre")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter between 3 and 30 characters")]
         public string Genre { get; set; }

        [Display(Name = "Name of the artist")]
        [Required(ErrorMessage = "Please input the name of the artist")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Artist { get; set; }

        [Display(Name = "Date of Recording")]
        [Required(ErrorMessage = "Please select the date of recording")]
        [DataType(DataType.Date)]
        public DateTime DateOfRecording { get; set; }

        
        public ICollection<Movie> Movies { get; set; }


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
            