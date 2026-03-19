using CapaDatos;
using CapaLogica;
using CapaModelos;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaLogicaTest
{
    public class LogicaEstudianteTest
    {
        [Fact]
        public void Revisar_Agregar_Estudiante_Exitoso()
        {
            var SustitutoEstudiantesBD = new Mock<CapaDatos.Interfaces.IEstudianteBD>();
            SustitutoEstudiantesBD.Setup(x => x.AgregarEstudiante(It.IsAny<Estudiante>())).Returns(true);

            var InstanciaLogicaEstudiantes = new LogicaEstudiante(SustitutoEstudiantesBD.Object);
            
            var resultado = InstanciaLogicaEstudiantes.AgregarEstudiante(new Estudiante());

            Assert.True(resultado);

            SustitutoEstudiantesBD.Verify(x => x.AgregarEstudiante(It.IsAny<Estudiante>()),Times.Once);  
        }

        [Fact]
        public void Revisar_Agregar_Estudiante_Fallido()
        {
            var SustitutoEstudiantesBD = new Mock<CapaDatos.Interfaces.IEstudianteBD>();
            SustitutoEstudiantesBD.Setup(x => x.AgregarEstudiante(It.IsAny<Estudiante>())).Returns(false);

            var InstanciaLogicaEstudiantes = new LogicaEstudiante(SustitutoEstudiantesBD.Object);

            var resultado = InstanciaLogicaEstudiantes.AgregarEstudiante(new Estudiante());

            Assert.False(resultado);

            SustitutoEstudiantesBD.Verify(x => x.AgregarEstudiante(It.IsAny<Estudiante>()), Times.Once);
        }

        [Fact]
        public void Revisar_ObtenerMenoresDeEdadConDatos()
        {
            List<Estudiante> ListaEstudiantesMenores = new List<Estudiante>();
            ListaEstudiantesMenores.Add(new Estudiante
            {
                Nombre = "Juan",
                Edad = 16
            });
            ListaEstudiantesMenores.Add(new Estudiante
            {
                Nombre = "Pedro",
                Edad = 15
            });
            ListaEstudiantesMenores.Add(new Estudiante
            {
                Nombre = "Maria",
                Edad = 16
            });

            var SustitutoEstudiantesBD = new Mock<CapaDatos.Interfaces.IEstudianteBD>();
            SustitutoEstudiantesBD.Setup(x => x.ObtenerMenoresEdad()).Returns(ListaEstudiantesMenores);

            var InstanciaLogicaEstudiantes = new LogicaEstudiante(SustitutoEstudiantesBD.Object);

            var resultado = InstanciaLogicaEstudiantes.ObtenerMenoresDeEdad();
            var resultadoEsperado = "Juan\r\nPedro\r\nMaria\r\n";

            Assert.Equal(resultado, resultadoEsperado);
            SustitutoEstudiantesBD.Verify(x => x.ObtenerMenoresEdad(), Times.Once);
        }

        [Fact]
        public void Revisar_ObtenerMenoresDeEdadSinDatos()
        {
            List<Estudiante> ListaEstudiantesMenores = new List<Estudiante>();

            var SustitutoEstudiantesBD = new Mock<CapaDatos.Interfaces.IEstudianteBD>();
            SustitutoEstudiantesBD.Setup(x => x.ObtenerMenoresEdad()).Returns(ListaEstudiantesMenores);
            SustitutoEstudiantesBD.Setup(x => x.ObtenerEstudiantes()).Returns(ListaEstudiantesMenores);
            SustitutoEstudiantesBD.Setup(x => x.AgregarEstudiante(It.IsAny<Estudiante>())).Returns(true);
            SustitutoEstudiantesBD.Setup(x => x.ActualizarEstudiante(It.IsAny<Estudiante>())).Returns(true);
            SustitutoEstudiantesBD.Setup(x => x.EliminarEstudiante(It.IsAny<int>())).Returns(true);

            var InstanciaLogicaEstudiantes = new LogicaEstudiante(SustitutoEstudiantesBD.Object);

            var resultado = InstanciaLogicaEstudiantes.ObtenerMenoresDeEdad();
            var resultadoEsperado = "";

            Assert.Equal(resultado, resultadoEsperado);
            SustitutoEstudiantesBD.Verify(x => x.ObtenerMenoresEdad(), Times.Once);
            SustitutoEstudiantesBD.Verify(x => x.ObtenerEstudiantes(), Times.Never);
            SustitutoEstudiantesBD.Verify(x => x.AgregarEstudiante(It.IsAny<Estudiante>()), Times.Never);
            SustitutoEstudiantesBD.Verify(x => x.ActualizarEstudiante(It.IsAny<Estudiante>()), Times.Never);
            SustitutoEstudiantesBD.Verify(x => x.EliminarEstudiante(It.IsAny<int>()), Times.Never);
        }
    }
}
