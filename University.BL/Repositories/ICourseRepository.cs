using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Repositories
{
    // Define el espacio de nombres University.BL.Repositories,
    // que organiza las interfaces y clases relacionadas con los repositorios.
    public interface ICourseRepository : IGenericRepository<Course>
    {
        // Declara una interfaz pública llamada ICourseRepository.
        // Esta interfaz hereda de IGenericRepository<Course>, lo que significa que
        // ICourseRepository incluye todas las operaciones definidas en IGenericRepository para la entidad Course.

        // Declara un método asíncrono llamado DeleteCheckOnEntity que toma un parámetro id de tipo int.
        // Devuelve un Task<bool>, lo que indica que el método se ejecutará de manera asíncrona
        // y, una vez completado, contendrá un valor booleano.
        Task<bool> DeleteCheckOnEntity(int id);
    }
}

