using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaModelos
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudiante { get; set; }
        public string? Nombre { get; set; }

        public int? Edad {  get; set; }

        public int CreditosAprobados { get; set; }

        public int CursosReprobados { get; set; }

        public List<Curso> Cursos { get; set; }
    }
}
