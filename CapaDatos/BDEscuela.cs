using Microsoft.EntityFrameworkCore;
using CapaModelos;

namespace CapaDatos
{
    public class BDEscuela:DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexion = "Data Source=localhost;Database=EscuelaNueva;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
            optionsBuilder.UseSqlServer(conexion);
        }
    }
}
