using Xunit;

namespace BackendApiTeste
{
    public class TenantTeste
    {
        [Fact]
        public async Task TesteValidaConexaoTenant()
        {
            // Arrange
            using var httpClient = new HttpClient();
            string apiUrl = "https://localhost:7076/api/v1/Tenant/Conexao";
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            // Act
            var content = response.Content.ReadAsStringAsync().Result;
            // Assert
            Assert.NotNull(content);
            Assert.Equal("Ok", content);
            //Assert.Contains("Ok", content, StringComparison.OrdinalIgnoreCase);
        }
    }
}
