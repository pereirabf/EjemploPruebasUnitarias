using CapaDatos;
using CapaModelos;
using Microsoft.EntityFrameworkCore;

namespace CapaDatosTest
{
    public class EstudiantesBDTest
    {
        [Fact]
        public void AgregarEstudianteExitoso()
        {
            var options = new DbContextOptionsBuilder<BDEscuela>()
                            .UseInMemoryDatabase(databaseName:"TestDatabase")
                            .Options;

            using var context = new BDEscuela(options);

            var InstanciaEstudiantesBD = new EstudianteBD(context);

            var Estudiante = new Estudiante
            {
                Nombre = "Maria",
                Edad = 20
            };

            var resultado = InstanciaEstudiantesBD.AgregarEstudiante(Estudiante);

            Assert.True(resultado);
            Assert.Single(context.Estudiantes);
            Assert.Equal("Maria",context.Estudiantes.First().Nombre);
        }
    }
}
