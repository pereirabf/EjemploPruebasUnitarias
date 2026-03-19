using Microsoft.EntityFrameworkCore;
using CapaModelos;
using CapaDatos.Interfaces;

namespace CapaDatos
{
    public class BDEscuela:DbContext
    {

        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Profesor> Profesores { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }

        public BDEscuela()
        {
        }

        public BDEscuela(DbContextOptions<BDEscuela> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conexion = "Data Source=localhost;Database=EscuelaNueva;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
                optionsBuilder.UseSqlServer(conexion);
            }
        }
    }
}
