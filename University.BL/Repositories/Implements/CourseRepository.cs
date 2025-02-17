using System.Data.Entity;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    // Define el espacio de nombres University.BL.Repositories.Implements,
    // que organiza las clases relacionadas con las implementaciones de los repositorios.
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        // La clase CourseRepository hereda de GenericRepository<T> donde T es Course,
        // e implementa la interfaz ICourseRepository.

        private readonly UniversityContext universityContext;
        // Campo privado readonly que almacena el contexto de la base de datos.
        // Se utiliza para interactuar con la base de datos de la universidad.

        public CourseRepository(UniversityContext universityContext) : base(universityContext)
        {
            // El constructor de CourseRepository recibe un objeto UniversityContext y
            // lo pasa al constructor de la clase base (GenericRepository<T>).
            this.universityContext = universityContext;
            // Asigna el objeto UniversityContext al campo privado universityContext.
            // Esto permite que la clase CourseRepository use el contexto de la base de datos.
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            // Método asíncrono que verifica si una entidad relacionada con el curso se puede eliminar.
            // Recibe un parámetro id de tipo int, que representa el ID del curso.

            var flag = await universityContext.Enrollments.AnyAsync(x => x.CourseID == id);
            // Llama al método AnyAsync del contexto de la base de datos (universityContext) 
            // en la tabla Enrollments para verificar si hay alguna inscripción con el CourseID proporcionado.
            // La palabra clave await espera la finalización de la tarea asíncrona y almacena el resultado en la variable flag.

            return flag;
            // Devuelve el resultado de la verificación.
            // true si hay inscripciones relacionadas con el curso, lo que significa que no se puede eliminar,
            // y false si no hay inscripciones, lo que significa que se puede eliminar.
        }
    }
}


