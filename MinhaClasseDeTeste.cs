using Xunit;

namespace BackendApiTeste
{
    public class MinhaClasseDeTeste
    {
        [Fact]
        public void MeuTesteDeExemplo()
        {
            // Arrange (preparação)
            var valor1 = 2;
            var valor2 = 3;

            // Act (ação)
            var resultado = valor1 + valor2;

            // Assert (afirmação)
            Assert.Equal(5, resultado);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 3, 6)]
        public void MeuTesteDeExemplo2(int n1, int n2, int res)
        {
            // Arrange (preparação)
            var valor1 = n1;
            var valor2 = n2;

            // Act (ação)
            var resultado = valor1 + valor2;

            // Assert (afirmação)
            Assert.Equal(res, resultado);
        }



    }
}
