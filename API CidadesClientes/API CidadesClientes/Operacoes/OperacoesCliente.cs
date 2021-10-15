using API_CidadesClientes.Contextos;
using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Operacoes
{
	public static class OperacoesCliente
	{
		public static void CriarClienteNovo(Cliente ClienteNovo, RecebeCidadeViaCepDTO ViaCepData, ClienteDbContext Contexto)
		{
			OperacoesCidade.OperarInfoCidade(ClienteNovo, ViaCepData, Contexto);
			Contexto.Clientes.Add(ClienteNovo);
			Contexto.SaveChanges();
		}
	}
}
