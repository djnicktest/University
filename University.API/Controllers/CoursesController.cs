using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers // Define el espacio de nombres para el controlador
{
    public class CoursesController : ApiController // Hereda de ApiController, lo que lo convierte en un controlador de API REST
    {
        private IMapper mapper; // Instancia de AutoMapper para convertir entre modelos y DTOs
        private readonly CourseService courseService =
            new CourseService(new CourseRepository(UniversityContext.Create()));
        // Se crea una instancia de CourseService pasando un CourseRepository que usa el contexto de base de datos

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            // Inicializa el mapper usando la configuración definida en WebApiApplication
        }

        // ---- MÉTODOS ----

        /// <summary>
        /// Obtiene todos los cursos
        /// </summary>
        /// <returns>Lista de todos los cursos</returns>
        /// <response code="200">OK. Devuelve la lista de cursos</response>
        [HttpGet] // Indica que este método maneja solicitudes HTTP GET
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll(); // Llama al servicio para obtener todos los cursos desde la BD
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            // Convierte la lista de Course a CourseDTO usando AutoMapper

            return Ok(coursesDTO); // Retorna un código 200 (OK) con la lista de cursos en formato DTO
        }

        /// <summary>
        /// Obtiene un curso por su ID.
        /// </summary>
        /// <remarks>Aqui puede ir una descripcion para detallada del objeto que retorna por su id </remarks>
        /// <param name="id">Id del curso</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">OK. Devuelve el curso solicitado</response>
        /// <response code="404">Not Found. No se ha encontrado el curso solicitado</response>
        [HttpGet] // Maneja solicitudes HTTP GET con un parámetro (ID)
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id); // Obtiene el curso por su ID desde el servicio
            if (course == null)
                return NotFound(); // Retorna 404 si el curso no existe

            var courseDTO = mapper.Map<CourseDTO>(course); // Convierte el objeto Course a CourseDTO
            return Ok(courseDTO); // Retorna 200 (OK) con el objeto convertido
        }

        /// <summary>
        /// Crea un nuevo curso.
        /// </summary>
        /// <param name="courseDTO">El objeto CourseDTO que contiene la información del curso a crear.</param>
        /// <returns>Un IHttpActionResult que indica el resultado de la operación.</returns>
        /// <response code="200">OK. Devuelve el curso creado.</response>
        /// <response code="400">Bad Request. Los datos del modelo no son válidos.</response>
        /// <response code="500">Internal Server Error. Ocurrió un error en el servidor.</response>
        [HttpPost] // Maneja solicitudes HTTP POST (crear un nuevo curso)
        [ResponseType(typeof(CourseDTO))] // Especifica el tipo de respuesta esperada
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Verifica si los datos del modelo son válidos

            try
            {
                var course = mapper.Map<Course>(courseDTO); // Convierte el DTO a entidad Course
                course = await courseService.Insert(course); // Llama al servicio para insertar el curso en la BD
                return Ok(course); // Retorna 200 (OK) con el curso insertado
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Manejo de errores, retorna un error 500
            }
        }

        /// <summary>
        /// Actualiza un curso existente.
        /// </summary>
        /// <param name="courseDTO"></param>
        /// <param name="id"></param>
        /// <returns>Un IHttpActionResult que indica el resultado de la operación.</returns>
        /// <response code="200">OK. Devuelve el curso creado.</response>
        /// <response code="400">Bad Request. Los IDS no coinciden o los datos del modelo no son válidos.</response>
        /// <response code="404">Not Found. El curso no existe.</response>
        /// <response code="500">Internal Server Error. Ocurrió un error en el servidor.</response>
        [HttpPut] // Maneja solicitudes HTTP PUT (actualizar un curso existente)
        [ResponseType(typeof(CourseDTO))] // Especifica el tipo de respuesta esperada
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Verifica si el modelo es válido

            if (courseDTO.CourseID != id) // Valida que el ID del DTO coincida con el ID de la URL
                return BadRequest();

            var flag = await courseService.GetById(id); // Verifica si el curso existe en la BD
            if (flag == null)
                return NotFound(); // Retorna 404 si el curso no existe

            try
            {
                var course = mapper.Map<Course>(courseDTO); // Convierte el DTO a entidad Course
                course = await courseService.Update(course); // Llama al servicio para actualizar el curso en la BD
                return Ok(course); // Retorna 200 (OK) con el curso actualizado
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Manejo de errores
            }
        }

        /// <summary>
        /// Elimina un curso existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un IHttpActionResult que indica el resultado de la operación.</returns>
        /// <response code="200">OK. Devuelve una respuesta exitosa del curso eliminado</response>
        /// <response code="400">Bad Request. Los datos del modelo no son válidos.</response>
        /// <response code="404">Not Found. El curso no existe.</response>
        /// <response code="500">Internal Server Error. Ocurrió un error en el servidor.</response>
        [HttpDelete] // Maneja solicitudes HTTP DELETE (eliminar un curso)
        [ResponseType(typeof(void))] // Especifica que no se espera un tipo de respuesta específica
        public async Task<IHttpActionResult> Delete(int id)
        {
            // Declara un método asíncrono que devuelve un IHttpActionResult.
            // Este método maneja la eliminación de un curso basado en su ID.
            var flag = await courseService.GetById(id);
            // Llama al método GetById del servicio courseService para obtener el curso con el ID proporcionado.
            // Espera (await) la finalización de la tarea asíncrona y almacena el resultado en la variable flag.

            if (flag == null)
                return NotFound();
            // Si el curso no se encuentra (flag es null), devuelve una respuesta 404 NotFound.

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                // Si no hay registros relacionados con el curso, elimina el curso llamando al método Delete del servicio courseService.
                // Espera (await) la finalización de la tarea asíncrona.

                else
                {
                    throw new Exception("The course has related records and can't be deleted.");
                    // Si hay registros relacionados con el curso, lanza una excepción con el mensaje especificado.
                }

                return Ok();
                // Si el curso se elimina correctamente, devuelve una respuesta 200 OK.
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                // Si ocurre una excepción durante la eliminación, captura la excepción y devuelve una respuesta 500 InternalServerError.
                // Pasa la excepción capturada al método InternalServerError para incluir detalles en la respuesta.
            }
        }


    }
}

