using University.BL.Models;
using University.BL.Repositories;
using System.Threading.Tasks;

namespace University.BL.Services.Implements
{
    internal class InstructorService : GenericService<Instructor>, IInstructorService
    {
        private readonly IInstructorRepository instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository) : base(instructorRepository)
        {
            // Aquí podrías agregar lógica específica para los cursos si es necesario.
            this.instructorRepository = instructorRepository;
        }
    }
}
