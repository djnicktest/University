using System;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The field LastName is required")]
        [StringLength(50, ErrorMessage = "The LastName field can only contain up to 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field FirstMidName is required")]
        [StringLength(50, ErrorMessage = "The FirstMidName field can only contain up to 50 characters")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "The field HireDate is required")]
        public DateTime HireDate { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); } //Lo que hace esta propiedad es juntar las dos variables existentes del nombre
        }

        public OfficeAssignmentDTO OfficeAssignment { get; set; }
    }
}
