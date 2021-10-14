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
		public IActionResult RerecebeClienteJSON(RecebeClienteDTO ClienteNovoDTO)
		{
			var Resultado = OperacoesViaCEP.BuscaEnderecoViaCep(ClienteNovoDTO.CEP);
			var ViaCepData = JsonConvert.DeserializeObject<RecebeCidadeViaCepDTO>(Resultado);
			Cliente ClienteNovo = mapper.Map<Cliente>(ClienteNovoDTO);
			OperarClienteNovo(ClienteNovo, ViaCepData);
			return CreatedAtAction(nameof(RetornaClientePorId), new { Id = ClienteNovo.Id }, ClienteNovoDTO);
		}

		private void OperarClienteNovo(Cliente ClienteNovo, RecebeCidadeViaCepDTO ViaCepData)
		{
			ClienteNovo.Bairro = ViaCepData.bairro;
			ClienteNovo.Logradouro = ViaCepData.logradouro;
			var CidadeRetornada = RetornaCidadeNovaOuEncontrada(ViaCepData);
			ClienteNovo.cidade = CidadeRetornada;
			Contexto.Clientes.Add(ClienteNovo);
			Contexto.SaveChanges();
		}

		private Cidade RetornaCidadeNovaOuEncontrada(RecebeCidadeViaCepDTO ViaCepData)
		{
			Cidade CidadeRetorno = Contexto.Cidades.FirstOrDefault(Ci => Ci.Nome == ViaCepData.localidade);
			if (CidadeRetorno == null)
			{
				Cidade NovaCidade = new Cidade();
				NovaCidade.Nome = ViaCepData.localidade;
				NovaCidade.Estado = ViaCepData.uf;
				return NovaCidade;
			}
			return CidadeRetorno;
		}

		[HttpGet]
		public void RetornaTodosOsClientes()
		{

		}

		[HttpGet("{id}")]
		public IActionResult RetornaClientePorId(Guid Id)
		{
			Cliente ClienteRetornado = Contexto.Clientes.FirstOrDefault(Cl => Cl.Id == Id);
			if (ClienteRetornado != null)
			{
				return Ok(ClienteRetornado);
			}
			else return NotFound();
		}

		[HttpDelete("{id}")]
		public void DeletaClientePorId(int Id)
		{

		}

		[HttpPut("id")]
		public void EditaClientePorId(int Id, [FromBody] EditaClienteDTO ClienteDTO)
		{

		}

		
	}
}
