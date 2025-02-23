using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.DTOs
{
    // Define el espacio de nombres University.BL.DTOs, 
    // que organiza el código relacionado con objetos de transferencia de datos (DTOs).
    public enum Grade
    {
        // Define una enumeración llamada Grade.
        // Las enumeraciones permiten definir un conjunto de constantes con nombre.
        A, B, C, D, F
    }

    public class EnrollmentDTO
    {
        // Define una clase interna llamada EnrollmentDTO.
        // Esta clase se usa para transferir datos relacionados con la inscripción (enrollment) de estudiantes en cursos.

        public int EnrollmentID { get; set; }
        // Propiedad pública que almacena el ID de la inscripción.
        // El método get obtiene el valor y el método set establece el valor.

        [Required(ErrorMessage = "The field CourseID is required")]
        public int CourseID { get; set; }
        // Propiedad pública que almacena el ID del curso.
        // Relaciona la inscripción con un curso específico.

        [Required(ErrorMessage = "The field StudentID is required")]
        public int StudentID { get; set; }
        // Propiedad pública que almacena el ID del estudiante.
        // Relaciona la inscripción con un estudiante específico.

        [Required(ErrorMessage = "The field Grade is required")]
        public Grade Grade { get; set; }
        // Propiedad pública que almacena el grado (Grade) obtenido en el curso.
        // Usa la enumeración Grade definida anteriormente.

        public CourseDTO Course { get; set; }
        // Propiedad pública que almacena información del curso relacionada con la inscripción.
        // Usa la clase CourseDTO para transferir datos del curso.

        public StudentDTO Student { get; set; }
        // Propiedad pública que almacena información del estudiante relacionada con la inscripción.
        // Usa la clase StudentDTO para transferir datos del estudiante.
    }
}

