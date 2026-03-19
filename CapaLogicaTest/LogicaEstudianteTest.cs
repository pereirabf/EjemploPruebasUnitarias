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
    }
}
