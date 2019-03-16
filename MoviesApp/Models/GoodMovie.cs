
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class GoodMovie
    {
        // CONSTRUCTOR
        public GoodMovie()
        {
            
        }

        // PRIMARY KEY - DO NOT REMOVE
        [Key]
        
        public int Id { get; set; }
        
        [Display(Name = "Name of the movie")]
        [Required(ErrorMessage = "Please input the name of the movie")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter between 5 and 100 characters")]
        public string Name { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }


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
            