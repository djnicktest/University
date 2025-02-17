using System.ComponentModel.DataAnnotations;


namespace University.BL.DTOs // Define el espacio de nombres para la clase. Los espacios de nombres organizan el código y evitan conflictos.
{
    public class CourseDTO // Declara una clase pública llamada CourseDTO. Esta clase se usa para transferir datos de cursos.
    {
        [Required(ErrorMessage = "The field ID is required")] // Indica que el campo CourseID es obligatorio. Si falta, se muestra el mensaje de error.
        public int CourseID { get; set; } // Propiedad pública para el ID del curso. Se usa para identificar de manera única cada curso.

        [Required(ErrorMessage = "The field Title is required")] // Indica que el campo Title es obligatorio. Si falta, se muestra el mensaje de error.
        [StringLength(50, ErrorMessage = "The Title field can only contain up to 50 characters")] // Restringe la longitud máxima del título a 50 caracteres. Si se excede, se muestra el mensaje de error.
        public string Title { get; set; } // Propiedad pública para el título del curso. Se usa para almacenar el nombre del curso.

        [Required(ErrorMessage = "The field Credits is required")] // Indica que el campo Credits es obligatorio. Si falta, se muestra el mensaje de error.
        public int Credits { get; set; } // Propiedad pública para los créditos del curso. Se usa para definir la cantidad de créditos asignados al curso.
    }
}

