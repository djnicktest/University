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
        public DbSet<Instructor> Instructors { get; set; } // Tabla de instructores
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; } // Tabla de asignaciones de oficina
        public DbSet<Department> Departments { get; set; } // Tabla de departamentos
        public DbSet<CourseInstructor> CourseInstructors { get; set; } // Tabla de instructores de cursos

        // Método estático para crear una nueva instancia del contexto
        public static UniversityContext Create()
        {
            return new UniversityContext(); // Devuelve una nueva instancia de UniversityContext
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración de las relaciones muchos a muchos entre Course e Instructor
            modelBuilder.Entity<CourseInstructor>()
                .HasKey(ci => new { ci.CourseID, ci.InstructorID });

            modelBuilder.Entity<CourseInstructor>()
                .HasRequired(ci => ci.Course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(ci => ci.CourseID);

            modelBuilder.Entity<CourseInstructor>()
                .HasRequired(ci => ci.Instructor)
                .WithMany(i => i.CourseInstructors)
                .HasForeignKey(ci => ci.InstructorID);


            //Configuracion de la relacion entre Instructor y OfficeAssignment
            modelBuilder.Entity<OfficeAssignment>()
                .HasKey(oa => oa.InstructorID);

            modelBuilder.Entity<OfficeAssignment>()
                .HasRequired(oa => oa.Instructor)
                .WithOptional(i => i.OfficeAssignment);
        }
    }
}

