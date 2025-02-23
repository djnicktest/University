using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "The field Location is required")]
        [StringLength(50, ErrorMessage = "The Location field can only contain up to 50 characters")]
        public string Location { get; set; }

        public InstructorDTO Instructor { get; set; }
    }
}
