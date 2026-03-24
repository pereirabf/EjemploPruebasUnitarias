using CapaDatos;
using CapaModelos;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CapaDatosTest
{
    public class EstudiantesBDTest
    {
        [Fact]
        public void AgregarEstudianteExitoso()
        {
        //Generaci[on de datos
            var options = new DbContextOptionsBuilder<BDEscuela>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
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
            Assert.Equal("Maria", context.Estudiantes.First().Nombre);
        }

        [Fact]
        public void AgregarEstudiante_DeberiaLlamarAddYSaveChanges()
        {
            // Arrange
            var data = new List<Estudiante>().AsQueryable();

            // Mock del DbSet<Estudiante>
            var SustitutoBaseDeDatos = new Mock<DbSet<Estudiante>>();
            SustitutoBaseDeDatos.As<IQueryable<Estudiante>>().Setup(m => m.Provider).Returns(data.Provider);
            SustitutoBaseDeDatos.As<IQueryable<Estudiante>>().Setup(m => m.Expression).Returns(data.Expression);
            SustitutoBaseDeDatos.As<IQueryable<Estudiante>>().Setup(m => m.ElementType).Returns(data.ElementType);
            SustitutoBaseDeDatos.As<IQueryable<Estudiante>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Mock del contexto BDEscuela
            var SustitutoContexto = new Mock<BDEscuela>();
            SustitutoContexto.Setup(c => c.Estudiantes).Returns(SustitutoBaseDeDatos.Object);
            SustitutoContexto.Setup(c => c.SaveChanges()).Returns(1);

            var estudianteBD = new EstudianteBD(SustitutoContexto.Object);
            var estudiante = new Estudiante { Nombre = "Ana" };

            // Act
            var resultado = estudianteBD.AgregarEstudiante(estudiante);

            // Assert
            Assert.True(resultado);
            SustitutoBaseDeDatos.Verify(m => m.Add(It.IsAny<Estudiante>()), Times.Once);       // Verifica que Add se llamó
            SustitutoContexto.Verify(m => m.SaveChanges(), Times.Once);                  // Verifica que SaveChanges se llamó
        }

        [Fact]
        public void prueba_eliminar_exitoso()
        {
            //Generar datos
            var options = new DbContextOptionsBuilder<BDEscuela>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            var context = new BDEscuela(options);

            var InstanciaEstudiantesBD = new EstudianteBD(context);

            //InstanciaEstudiantesBD.AgregarEstudiante(new Estudiante() { Nombre = "Pedro" });
            context.Estudiantes.Add(new Estudiante() { Nombre = "Pedro" });
            context.SaveChanges();

            //Ejecuci[on
            var resultado = InstanciaEstudiantesBD.EliminarEstudiante(1);

            //Verificaci[on del resultado
            Assert.True(resultado);

        }

        [Fact]
        public void prueba_eliminar_fallido()
        {
            //Generar datos
            var options = new DbContextOptionsBuilder<BDEscuela>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            var context = new BDEscuela(options);

            var InstanciaEstudiantesBD = new EstudianteBD(context);

            //InstanciaEstudiantesBD.AgregarEstudiante(new Estudiante() { Nombre = "Pedro" });

            //Ejecuci[on
            var resultado = InstanciaEstudiantesBD.EliminarEstudiante(2);

            //Verificaci[on del resultado
            Assert.False(resultado);

        }
    }
}
