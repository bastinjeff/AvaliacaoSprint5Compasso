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
using Microsoft.EntityFrameworkCore;
using API_CidadesClientes.Models.DTOs.CidadeDTOs;

namespace API_CidadesClientes.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : MainController
	{
		public ClienteController(ClienteDbContext Contexto, IMapper mapper) : base(Contexto,mapper)
		{
		}

		[HttpPost]
		public IActionResult RerecebeClienteJSON(RecebeClienteDTO ClienteNovoDTO)
		{
			var ViaCepData = OperacoesViaCEP.RetornaObjetoViaCep(ClienteNovoDTO.CEP);
			Cliente ClienteNovo = mapper.Map<Cliente>(ClienteNovoDTO);
			OperarClienteNovo(ClienteNovo, ViaCepData);
			return CreatedAtAction(nameof(RetornaClientePorId), new { Id = ClienteNovo.Id }, ClienteNovoDTO);
		}

		private void OperarClienteNovo(Cliente ClienteNovo, RecebeCidadeViaCepDTO ViaCepData)
		{
			OperarInfoCidade(ClienteNovo, ViaCepData);
			Contexto.Clientes.Add(ClienteNovo);
			Contexto.SaveChanges();
		}

		private void OperarInfoCidade(Cliente ClienteAtual, RecebeCidadeViaCepDTO ViaCepData)
		{
			ClienteAtual.Bairro = ViaCepData.bairro;
			ClienteAtual.Logradouro = ViaCepData.logradouro;
			var CidadeRetornada = RetornaCidadeNovaOuEncontrada(ViaCepData);
			ClienteAtual.cidade = CidadeRetornada;
		}

		private Cidade RetornaCidadeNovaOuEncontrada(RecebeCidadeViaCepDTO ViaCepData)
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

		[HttpGet]
		public IActionResult RetornaTodosOsClientes()
		{
			IEnumerable<Cliente> TodosOsClientes = Contexto.Clientes.Include(X => X.cidade);
			var TodosOsClientesDTO = mapper.Map<IEnumerable<RetornaClienteDTO>>(TodosOsClientes);
			return Ok(TodosOsClientesDTO);
		}

		[HttpGet("{id}")]
		public IActionResult RetornaClientePorId(Guid Id)
		{
			Cliente ClienteDoDB = Contexto.Clientes.Include(X => X.cidade).FirstOrDefault(Cl => Cl.Id == Id);			
			
			if (ClienteDoDB != null)
			{							
				RetornaClienteDTO ClienteRetornado = mapper.Map<RetornaClienteDTO>(ClienteDoDB);
				return Ok(ClienteRetornado);
			}
			else return NotFound();
		}

		[HttpDelete("{id}")]
		public IActionResult DeletaClientePorId(Guid Id)
		{
			Cliente ClienteDoDB = Contexto.Clientes.FirstOrDefault(Cl => Cl.Id == Id);
			if(ClienteDoDB == null)
			{
				return NotFound();
			}
			Contexto.Remove(ClienteDoDB);
			Contexto.SaveChanges();
			return NoContent();
		}

		[HttpPut("{id}")]
		public IActionResult EditaClientePorId(Guid Id, [FromBody] EditaClienteDTO ClienteDTO)
		{
			Cliente ClienteDoDB = Contexto.Clientes.FirstOrDefault(Cl => Cl.Id == Id);
			if(ClienteDoDB == null)
			{
				return NotFound();
			}
			string CepOriginal = ClienteDoDB.CEP;
			RecebeCidadeViaCepDTO ViaCepData = new RecebeCidadeViaCepDTO();

			mapper.Map(ClienteDTO, ClienteDoDB);
			if (CepOriginal != ClienteDoDB.CEP)
			{
				ViaCepData = OperacoesViaCEP.RetornaObjetoViaCep(ClienteDTO.CEP);
				OperarInfoCidade(ClienteDoDB, ViaCepData);
			}			
			Contexto.SaveChanges();
			return NoContent();

		}


	}
}
