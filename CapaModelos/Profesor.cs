using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaModelos
{
    public class Profesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodProfesor{ get; set; }

        [MaxLength (50)]
        public string Nombre {  get; set; }
        public int Experiencia {  get; set; }
    }
}
