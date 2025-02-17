using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.BL.Models
{
    // Define el espacio de nombres University.BL.Models,
    // que organiza las clases relacionadas con el modelo de datos de la universidad.
    [Table("Course", Schema = "dbo")]
    public class Course
    {
        // El atributo [Table] especifica el nombre de la tabla en la base de datos
        // y el esquema al que pertenece esta clase.
        // En este caso, la tabla se llama "Course" y pertenece al esquema "dbo".

        [Key]
        // El atributo [Key] indica que la propiedad CourseID es la clave primaria de la tabla.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // El atributo [DatabaseGenerated] con la opción None especifica que el valor de CourseID
        // no se generará automáticamente en la base de datos.
        public int CourseID { get; set; }
        // Propiedad pública que almacena el ID del curso.
        // Los métodos get y set permiten acceder y modificar el valor de esta propiedad.

        public string Title { get; set; }
        // Propiedad pública que almacena el título del curso.
        // Los métodos get y set permiten acceder y modificar el valor de esta propiedad.

        public int Credits { get; set; }
        // Propiedad pública que almacena el número de créditos del curso.
        // Los métodos get y set permiten acceder y modificar el valor de esta propiedad.

        public ICollection<Enrollment> Enrollments { get; set; }
        // Propiedad pública que almacena una colección de inscripciones (Enrollments) asociadas con el curso.
        // Una colección se usa aquí porque un curso puede tener múltiples inscripciones.

        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        // Propiedad pública que almacena una colección de instructores (CourseInstructors) asociados con el curso.
        // La palabra clave "virtual" permite la carga diferida (lazy loading) de esta propiedad.
    }
}

