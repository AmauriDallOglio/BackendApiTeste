using Xunit;

namespace BackendApiTeste
{
    public class AtivoLocalTeste
    {
        [Fact]
        public async Task TesteValidaConexaoAtivoLocal()
        {
            // Arrange
            using var httpClient = new HttpClient();
            string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            // Act
            var content = response.Content.ReadAsStringAsync().Result;
            // Assert
            Assert.NotNull(content);
            Assert.Equal("Ok", content);
        }
    }
}
