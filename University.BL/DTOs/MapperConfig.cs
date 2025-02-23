using AutoMapper;
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
                // Mapeos bidireccionales usando ReverseMap()
                cfg.CreateMap<Course, CourseDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
                cfg.CreateMap<Instructor, InstructorDTO>().ReverseMap();
                cfg.CreateMap<OfficeAssignment, OfficeAssignmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<CourseInstructor, CourseInstructorDTO>().ReverseMap();
            });
        }
    }
}


