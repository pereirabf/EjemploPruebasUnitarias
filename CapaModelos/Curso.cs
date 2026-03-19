using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaModelos
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCurso { get; set; }
        public string Nombre {  get; set; }
        public Profesor Profesor { get; set; }
        public List<Estudiante> Estudiantes { get; set; }

        public string Horario {  get; set; }

    }
}
