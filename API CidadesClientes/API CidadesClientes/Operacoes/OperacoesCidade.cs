using API_CidadesClientes.Contextos;
using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Operacoes
{
	public static class OperacoesCidade
	{
		public static void OperarInfoCidade(Cliente ClienteAtual, RecebeCidadeViaCepDTO ViaCepData, ClienteDbContext Contexto)
		{
			ClienteAtual.Bairro = ViaCepData.bairro;
			ClienteAtual.Logradouro = ViaCepData.logradouro;
			var CidadeRetornada = RetornaCidadeNovaOuEncontrada(ViaCepData, Contexto);
			ClienteAtual.cidade = CidadeRetornada;
		}

		public static Cidade RetornaCidadeNovaOuEncontrada(RecebeCidadeViaCepDTO ViaCepData, ClienteDbContext Contexto)
		{
			Cidade CidadeRetorno = Contexto.Cidades.FirstOrDefault(Ci => Ci.Nome == ViaCepData.localidade && Ci.Estado == ViaCepData.uf);
			if (CidadeRetorno == null)
			{
				Cidade NovaCidade = new Cidade();
				NovaCidade.Nome = ViaCepData.localidade;
				NovaCidade.Estado = ViaCepData.uf;
				return NovaCidade;
			}
			return CidadeRetorno;
		}
	}
}
