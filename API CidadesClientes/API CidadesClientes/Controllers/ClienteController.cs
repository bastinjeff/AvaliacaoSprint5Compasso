using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs.ClienteDTOs;
using System.Net;
using System.IO;
using API_CidadesClientes.Contextos;
using AutoMapper;
using Newtonsoft.Json;
using API_CidadesClientes.Models.DTOs;

namespace API_CidadesClientes.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : ControllerBase
	{
		private ClienteDbContext Contexto;
		private IMapper mapper;
		public ClienteController(ClienteDbContext Contexto, IMapper mapper)
		{
			this.Contexto = Contexto;
			this.mapper = mapper;
		}
		[HttpPost]
		public void RerecebeClienteJSON(RecebeClienteDTO ClienteNovo)
		{
			Console.WriteLine(ClienteNovo.CEP);
			var Resultado = OperacoesViaCEP.BuscaEnderecoViaCep(ClienteNovo.CEP);
			var ViaCep = JsonConvert.DeserializeObject<RecebeCidadeViaCepDTO>(Resultado);
			Console.WriteLine(ViaCep.bairro);
		}

		[HttpGet]
		public void RetornaTodosOsClientes()
		{

		}

		[HttpGet("{id}")]
		public void RetornaClientePorId(int Id, [FromBody] EditaClienteDTO ClienteDTO)
		{

		}

		[HttpDelete("{id}")]
		public void DeletaClientePorId(int Id)
		{

		}

		[HttpPut("id")]
		public void EditaClientePorId(int Id)
		{

		}

		
	}
}
