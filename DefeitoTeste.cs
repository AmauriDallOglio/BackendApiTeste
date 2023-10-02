using Xunit;

namespace BackendApiTeste
{
    public class DefeitoTeste
    {
        [Fact]
        public async Task TesteValidaConexaoDefeito()
        {
            // Arrange
            using var httpClient = new HttpClient();
            string apiUrl = "https://localhost:7076/api/v1/Defeito/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            // Act
            var content = response.Content.ReadAsStringAsync().Result;
            // Assert
            Assert.NotNull(content);
            Assert.Equal("Ok", content);
        }
    }
}
