using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly UniversityContext universityContext;
        public InstructorRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }
    } 
}
