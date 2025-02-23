using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public  class CourseInstructorDTO
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }

        //Propiedades de navegacion
        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
