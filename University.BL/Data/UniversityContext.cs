using System.Data.Entity;
using University.BL.Models;

namespace University.BL.Data // Define el espacio de nombres donde se encuentra la clase
{
    public class UniversityContext : DbContext // Hereda de DbContext, lo que lo convierte en un contexto de EF
    {
        private static UniversityContext universityContext = null; // Variable estática para una posible instancia única

        public UniversityContext()
            : base("UniversityContext") // Llama al constructor de DbContext con el nombre de la cadena de conexión
        {
            // Aquí se establece la conexión con la base de datos usando la configuración en Web.config o appsettings.json
        }

        // Definición de DbSet para representar las tablas en la base de datos
        public DbSet<Course> Courses { get; set; } // Tabla de cursos
        public DbSet<Student> Students { get; set; } // Tabla de estudiantes
        public DbSet<Enrollment> Enrollments { get; set; } // Tabla de inscripciones

        // Método estático para crear una nueva instancia del contexto
        public static UniversityContext Create()
        {
            return new UniversityContext(); // Devuelve una nueva instancia de UniversityContext
        }
    }
}

