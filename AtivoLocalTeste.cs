using Newtonsoft.Json;
using System.Text;
using static BackendApiTeste.EntidadeModelo;

namespace BackendApiTeste
{
    public class AtivoLocalTeste
    {
        [Fact]
        public void Valida_Conexao_DeveRetornarSucesso()
        {
            try
            {
                // Arrange preparação
                using var httpClient = new HttpClient();
                string apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Conexao";
                HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                // Act ação
                var content = response.Content.ReadAsStringAsync().Result;
                // Assert afirmação
                Assert.NotNull(content);
                Assert.Equal("Ok", content);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro de HTTP: {ex.Message}");
            }
        }

        [Fact]
        public void Obter_Lista_DeveRetornarSucesso()
        {
            // Arrange
            using var httpClient = new HttpClient();
            string pesquisa = "!Xunit_AtivoLocal!";
            string apiUrl = $"https://localhost:7076/api/v1/AtivoLocal/ListarTodos?Descricao={pesquisa}";

            // Act
            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<ListarTodos> listagem = JsonConvert.DeserializeObject<List<ListarTodos>>(content);

            // Assert
            Assert.Equal("OK", response.ReasonPhrase);
            Assert.IsType<List<ListarTodos>>(listagem);
        }



        [Fact]
        public async Task Executa_Inclui_DeveRetornarSucesso()
        {
            //Guid tenantId = Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814"); //c
            Guid tenantId = Guid.Parse("62643056-F34C-EE11-9829-5CCD5B8BDCFF"); //o
            using var httpClient = new HttpClient();
            var apiUrl = "https://localhost:7076/api/v1/AtivoLocal/Inserir";
            var dto = new AtivoLocalDto
            {
                Area = "Area teste",
                Descricao = "!Xunit_AtivoLocal! Descrição teste",
                Referencia = "!Xunit_AtivoLocal!",
                Id_Tenant = tenantId,
                Setor = "Setor teste"
            };

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var novo = JsonConvert.DeserializeObject<Resposta>(responseContent);

            // Assert
            Assert.NotNull(novo);
            Assert.True(novo.Sucesso);
            Assert.NotNull(novo.Modelo.Id);
            Assert.IsType<Resposta>(novo);

        }


        [Fact]
        public async Task Executa_Excluir_DeveRetornarSucesso()
        {
            //Guid tenantId = Guid.Parse("A31CF8A0-7B4D-EE11-A89E-F0D41578B814"); //c
            Guid tenantId = Guid.Parse("62643056-F34C-EE11-9829-5CCD5B8BDCFF"); //o

            using var httpClient = new HttpClient();
            string pesquisa = "!Xunit_AtivoLocal!";
            string apiUrl = $"https://localhost:7076/api/v1/AtivoLocal/ListarTodos?Descricao={pesquisa}";

            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<ListarTodos> listagem = JsonConvert.DeserializeObject<List<ListarTodos>>(content);

            foreach (var item in listagem)
            {
                string apiUrlDelete = "https://localhost:7076/api/v1/AtivoLocal/Excluir";
                Excluir requestData = new Excluir
                {
                    Id = item.Id
                };
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiUrlDelete)
                {
                    Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json")
                };
                HttpResponseMessage responseDelete = await httpClient.SendAsync(request);

                // Assert
                Assert.Equal("OK", responseDelete.ReasonPhrase);
                Assert.IsType<List<ListarTodos>>(listagem);
            }
        }
    }
}
