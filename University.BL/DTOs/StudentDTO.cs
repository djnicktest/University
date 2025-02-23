using System;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class StudentDTO
    {

        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Title field can only contain up to 50 characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Title field can only contain up to 50 characters")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "The field EnrollmentDate is required")] 
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); } //Lo que hace esta propiedad es juntar las dos variables existentes del nombre
        }
    }
}
