global using Xunit;
using BackendApiTeste;

AtivoLocalTeste ativoLocalTeste = new AtivoLocalTeste();
ativoLocalTeste.Valida_Conexao_DeveRetornarSucesso();
ativoLocalTeste.Obter_Lista_DeveRetornarSucesso();
ativoLocalTeste.Executa_Inclui_DeveRetornarSucesso();
ativoLocalTeste.Executa_Excluir_DeveRetornarSucesso();

