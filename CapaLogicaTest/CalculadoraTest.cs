using CapaLogica;

namespace CapaLogicaTest
{
    public class CalculadoraTest
    {
        [Fact]
        public void prueba_sumar()
        {
            var calcularora = new Calculadora();

            var resultado = calcularora.sumar(2, 3);

            Assert.Equal(5, resultado);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(5, 5, 10)]
        [InlineData(4, 8, 12)]
        public void Sumar_multiples_casos(int a,int b, int esperado)
        {
            var calc = new Calculadora();

            var resultado = calc.sumar(a, b);

            Assert.Equal(esperado, resultado);
        }
    }
}
