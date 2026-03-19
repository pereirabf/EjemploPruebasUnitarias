using CapaDatos.Interfaces;
using CapaModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos
{
    public class EstudianteBD: IEstudianteBD
    {
        private BDEscuela EscuelaNueva;

        public EstudianteBD()
        {
            EscuelaNueva = new BDEscuela();
            EscuelaNueva.Database.Migrate();
        }

        public EstudianteBD(BDEscuela instanciaBD)
        {
            EscuelaNueva = instanciaBD;
        }

        public bool AgregarEstudiante(Estudiante estudiante)
        {
            EscuelaNueva.Estudiantes.Add(estudiante);
            return EscuelaNueva.SaveChanges() > 0;
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return EscuelaNueva.Estudiantes.ToList<Estudiante>();
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            Estudiante estudianteAActualizar = EscuelaNueva.Estudiantes.Find(estudiante.IdEstudiante);
            bool Actualizado = false;
            if (estudianteAActualizar != null) 
            {
                estudianteAActualizar.IdEstudiante = estudiante.IdEstudiante;
                estudianteAActualizar.Nombre = estudiante.Nombre;
                estudianteAActualizar.Edad = estudiante.Edad;
                Actualizado = EscuelaNueva.SaveChanges() > 0;
            }

            return Actualizado;
        }

        public bool EliminarEstudiante(int idEstdianteAEliminar)
        {
            Estudiante estudianteAEliminar = EscuelaNueva.Estudiantes.Find(idEstdianteAEliminar);
            bool Elminado = false;
            if (estudianteAEliminar != null)
            {
                EscuelaNueva.Estudiantes.Remove(estudianteAEliminar);
                Elminado = EscuelaNueva.SaveChanges() > 0;
            }

            return Elminado;
        }

        public List<Estudiante> ObtenerMenoresEdad()
        {
            List<Estudiante> menores = EscuelaNueva.Estudiantes.ToList();
            return menores.Where(e => e.Edad < 18).ToList();
        }


    }
}
