using Xunit;

namespace BackendApiTeste
{
    public class AtivoTipoTeste
    {
        [Fact]
        public async Task TesteValidaConexaoAtivoTipo()
        {
            // Arrange
            using var httpClient = new HttpClient();
            string apiUrl = "https://localhost:7076/api/v1/AtivoTipo/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            // Act
            var content = response.Content.ReadAsStringAsync().Result;
            // Assert
            Assert.NotNull(content);
            Assert.Equal("Ok", content);
        }
    }
}
