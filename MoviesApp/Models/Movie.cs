
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Movie
    {
        // CONSTRUCTOR
        public Movie()
        {
            
        }

        // PRIMARY KEY - DO NOT REMOVE
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name of the movie")]
        [Required(ErrorMessage = "Please input the name of the movie")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Budget $(000)")]
        [Required(ErrorMessage = "Please enter the budget in thousands of $")]
        [Range(0, 1000000, ErrorMessage = "Enter a value between 0-1000000")]
        public int Budget { get; set; }

        [Display(Name = "Box-Office Collection $(000)")]
        [Required(ErrorMessage = "Please enter the Box-Office Collection in thousands of $")]
        [Range(0, 1000000, ErrorMessage = "Enter a value between 0-1000000")]
        public int BOCollection { get; set; }

        [Display(Name = "Rating (1-5)")]
        [Required(ErrorMessage = "Please enter a value for the rating")]
        [Range(1, 5, ErrorMessage = "Enter a value between 1-5")]
        public int Rating { get; set; }

        [Display(Name = "Date of release")]
        [Required(ErrorMessage = "Please select the date of release")]
        [DataType(DataType.Date)]
        public DateTime DateofRelease { get; set; }

        [Display(Name = "Is it a recommended watch?")]
        public bool Isrecommended { get; set; }
        
        [Display(Name = "Date the movie was last played in theatre")]
        [DataType(DataType.Date)]
        public DateTime? DateLastPlayed { get; set; }
        
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        
        [Display(Name = "Studio")]
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        
        [Display(Name = "Soundtrack")]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        
        public bool IsCurrentlyRunning {
            get { return DateLastPlayed == null; }
        }

        public bool IsAHit {
            get { return BOCollection > Budget; }
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
            