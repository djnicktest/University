using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.BL.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50, ErrorMessage = "The Name field can only contain up to 50 characters")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "El presupuesto no puede ser negativo.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "The field StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field InstructorID is required")]
        public int InstructorID { get; set; }

        //propiedades de navegacion
        public InstructorDTO Instructor { get; set; }
    }
}
