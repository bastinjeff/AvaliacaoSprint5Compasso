using API_CidadesClientes.Contextos;
using API_CidadesClientes.Models;
using API_CidadesClientes.Operacoes;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Projeto_De_Testes_Automaticos
{
	public class TestesOperacoesCidade : TestesOperacoesClienteDbContextBase
	{
		public TestesOperacoesCidade() : base()
		{
			
		}
		[Fact]
		public void QuandoExecutarOperarCidadeDeveRetornarInfoCompleta()
		{
			//arrange
			string CEP = "01001000";
			var ViaCepData = OperacoesViaCEP.RetornaObjetoViaCep(CEP);
			var ClienteDeTeste = new Cliente();
			ClienteDeTeste.Nome = "Cliente De Teste";
			//execute
			OperacoesCidade.OperarInfoCidade(ClienteDeTeste, ViaCepData, Contexto);
			//assert
			Assert.NotNull(ClienteDeTeste.Bairro);
			Assert.NotNull(ClienteDeTeste.Logradouro);
			Assert.NotNull(ClienteDeTeste.cidade);
		}

		[Fact]
		public void QuandoExecutarRetornaCidadeDeveRetornarCidadeNaoNula()
		{
			//arrange
			string CEP = "01001000";
			var ViaCepData = OperacoesViaCEP.RetornaObjetoViaCep(CEP);
			//execute
			var CidadeRetornada = OperacoesCidade.RetornaCidadeNovaOuEncontrada(ViaCepData, Contexto);
			//assert
			Assert.NotNull(CidadeRetornada);
		}
	}
}
