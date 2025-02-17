using AutoMapper;
using System.Data.Entity;
using University.BL.Models;

namespace University.BL.DTOs
{
    // Define el espacio de nombres University.BL.DTOs, 
    // que organiza el código relacionado con objetos de transferencia de datos (DTOs).
    public class MapperConfig
    {
        // Define un método estático que devuelve una configuración de mapeo de AutoMapper.
        // Este método configura cómo se mapearán los objetos entre sí.
        public static MapperConfiguration MapperConfiguration()
        {
            // Crea y devuelve una nueva instancia de MapperConfiguration.
            // La configuración se define mediante expresiones lambda en cfg.
            return new MapperConfiguration(cfg =>
            {
                // Define cómo mapear un objeto de tipo Course a CourseDTO.
                // Esto se utiliza generalmente para operaciones de lectura (GET).
                cfg.CreateMap<Course, CourseDTO>();

                // Define cómo mapear un objeto de tipo CourseDTO a Course.
                // Esto se utiliza para operaciones de escritura (PUT, POST).
                cfg.CreateMap<CourseDTO, Course>();

                // Define cómo mapear un objeto de tipo Student a StudentDTO.
                cfg.CreateMap<Student, StudentDTO>();

                // Define cómo mapear un objeto de tipo StudentDTO a Student.
                cfg.CreateMap<StudentDTO, Student>();

                // Define cómo mapear un objeto de tipo Enrollment a EnrollmentDTO.
                cfg.CreateMap<Enrollment, EnrollmentDTO>();

                // Define cómo mapear un objeto de tipo EnrollmentDTO a Enrollment.
                cfg.CreateMap<EnrollmentDTO, Enrollment>();
            });
        }
    }
}


