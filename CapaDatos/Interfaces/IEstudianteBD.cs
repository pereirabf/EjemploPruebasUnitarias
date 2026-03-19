using CapaModelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos.Interfaces
{
    public interface IEstudianteBD
    {
        public bool AgregarEstudiante(Estudiante estudiante);
        public List<Estudiante> ObtenerEstudiantes();
        public bool ActualizarEstudiante(Estudiante estudiante);
        public bool EliminarEstudiante(int idEstdianteAEliminar);
        public List<Estudiante> ObtenerMenoresEdad();

    }
}
