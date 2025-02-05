using AutoMapper;
using System.Data.Entity;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();// esta parte utiliza los metodos Get
                cfg.CreateMap<CourseDTO, Course>();// esta parte se encargan de recibir la informacion de los metodos put, post 

                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();

                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentDTO, Enrollment>();
            });
         
        }
    }
}
             
