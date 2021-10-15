using API_CidadesClientes;
using System;
using Xunit;

namespace Projeto_De_Testes_Automaticos
{
	public class TestesOperacoesViaCEP
	{
		[Fact]
		public void QuandoOperacoesViaCEPReceberCepRetornaObjetoNaoNulo()
		{
			//arrange
			string CEPTeste = "01001000";
			//act
			var ObjetoRetornado = OperacoesViaCEP.RetornaObjetoViaCep(CEPTeste);
			//assert
			Assert.NotNull(ObjetoRetornado);
		}

		[Fact]
		public void QuandoOperacoesViaCEPReceberCepInexistenteRetornarPropErroTrue()
		{
			//arrange
			string CEPFalho = "12345678";
			//act
			var ObjetoRetornado = OperacoesViaCEP.RetornaObjetoViaCep(CEPFalho);
			//assert
			Assert.True(ObjetoRetornado.erro);
		}
	}
}
