using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers
{
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));//consulta implementada Srvicios-Repositorios-contexto de datos (Create)

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();//El mapper y el patron DTO 
        }

        [HttpGet]//Tipo de metodo
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));

            return Ok(coursesDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null)
                return NotFound();

            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);//Validacion de que si el Modelo es Valido

            
            try
            {
                var course = mapper.Map<Course>(courseDTO);//La conversion del objeto
                course = await courseService.Insert(course);// la insercion atraves del servicio y el repositorio
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }// retorne un OK con el status 200 y el objeto que se acabo de insertar. 
        }

        [HttpPut]

        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)//Aparte de recibir un objeto en el cuerpo de la peticion tambien recibe un parametro por url
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);// Aca se valida de que el modelo sea valido 

            if (courseDTO.CourseID != id)//se valida el id que se esta enviando que sea coherente con el de la base de datos
                return BadRequest();

            var flag = await courseService.GetById(id);// Validacion del objeto el cual se intenta modificar exista
            if (flag == null)
                return  NotFound();//si no existe se retorna un not found

            try
            {
                var course = mapper.Map<Course>(courseDTO);//se valida y se hace la convercion del DTO al Course que se intenta modificar
                course = await courseService.Update(course);//se llama el metodo Update
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }
            }

    }
}
