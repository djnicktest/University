using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services
{
    // Define el espacio de nombres University.BL.Services,
    // que organiza las interfaces y clases relacionadas con los servicios.
    public interface ICourseService : IGenericService<Course>
    {
        // Declara una interfaz pública llamada ICourseService.
        // Esta interfaz hereda de IGenericService<Course>, lo que significa que
        // ICourseService incluye todas las operaciones definidas en IGenericService para la entidad Course.

        // Declara un método asíncrono llamado DeleteCheckOnEntity que toma un parámetro id de tipo int.
        // Devuelve un Task<bool>, lo que indica que el método se ejecutará de manera asíncrona
        // y, una vez completado, contendrá un valor booleano.
        Task<bool> DeleteCheckOnEntity(int id);
    }
}

