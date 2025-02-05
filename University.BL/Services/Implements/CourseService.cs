using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements // Espacio de nombres donde se encuentra esta clase.
{
    // Definimos la clase CourseService que administra la lógica de negocio para los cursos.
    // Hereda de GenericService<Course>, lo que significa que reutiliza funcionalidades genéricas.
    public class CourseService : GenericService<Course>, ICourseService
    {
        // Constructor de la clase CourseService.
        // Recibe un objeto que implementa la interfaz ICourseRepository.
        // Luego, llama al constructor de la clase padre (GenericService) para inicializarlo.
        public CourseService(ICourseRepository courseRepository) : base(courseRepository)
        {
            // Aquí podrías agregar lógica específica para los cursos si es necesario.
        }
    }
}
