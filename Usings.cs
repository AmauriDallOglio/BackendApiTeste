global using Xunit;
using BackendApiTeste;

AtivoLocalTeste ativoLocalTeste = new AtivoLocalTeste();
//ativoLocalTeste.TesteValidaConexao();
ativoLocalTeste.TesteListarTodos();
ativoLocalTeste.TesteIncluir();
ativoLocalTeste.TesteExcluir();




