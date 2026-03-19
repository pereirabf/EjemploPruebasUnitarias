using CapaDatos;
using CapaModelos;

namespace CapaLogica
{
    public class LogicaEstudiante
    {
        private CapaDatos.Interfaces.IEstudianteBD InstanciaEstudianteBD;

        public LogicaEstudiante()
        {
            InstanciaEstudianteBD = new EstudianteBD();
        }

        public LogicaEstudiante(CapaDatos.Interfaces.IEstudianteBD instanciaEstudianteBD)
        {
            InstanciaEstudianteBD = instanciaEstudianteBD;
        }

        public bool AgregarEstudiante(Estudiante estudiante)
        {
            return InstanciaEstudianteBD.AgregarEstudiante(estudiante);
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return InstanciaEstudianteBD.ObtenerEstudiantes();
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            return InstanciaEstudianteBD.ActualizarEstudiante(estudiante);
        }

        public bool EliminarEstudiante(int estudiante)
        {
            return InstanciaEstudianteBD.EliminarEstudiante(estudiante);
        }

        public string ObtenerMenoresDeEdad()
        {
            string ListaEstudiantes = "";
            foreach (Estudiante e in InstanciaEstudianteBD.ObtenerMenoresEdad()) 
            {
                ListaEstudiantes += e.Nombre +Environment.NewLine;
            }
            return ListaEstudiantes;
        }
    }
}
