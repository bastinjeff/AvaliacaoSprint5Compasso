using API_CidadesClientes.Contextos;
using API_CidadesClientes.Models;
using API_CidadesClientes.Operacoes;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Projeto_De_Testes_Automaticos
{
	public class TestesOperacoesCliente : TestesOperacoesClienteDbContextBase
	{
		public TestesOperacoesCliente() : base()
		{
			
		}
		[Fact]
		public void QuandoReceberClienteValidoInserirEmBancoDeDados()
		{
			//arrange
			string CEP = "01001000";
			var ViaCepData = OperacoesViaCEP.RetornaObjetoViaCep(CEP);
			var ClienteDeTeste = new Cliente();
			ClienteDeTeste.Nome = "Cliente De Teste";
			//execute
			OperacoesCliente.CriarClienteNovo(ClienteDeTeste, ViaCepData, Contexto);
			//assert
			Assert.NotEmpty(Contexto.Clientes);
		}
	}
}
