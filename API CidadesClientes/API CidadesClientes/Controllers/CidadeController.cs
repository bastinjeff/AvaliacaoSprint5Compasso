using API_CidadesClientes.Contextos;
using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs.CidadeDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CidadeController : MainController
	{
		public CidadeController(ClienteDbContext Contexto, IMapper mapper) : base(Contexto, mapper)
		{

		}
		[HttpPost]
		public IActionResult InsereCidade([FromBody] RecebeCidadeDTO CidadeDTO)
		{
			var CidadeNova = mapper.Map<Cidade>(CidadeDTO);
			var Contem = Contexto.Cidades.FirstOrDefault(Ci => Ci.Nome == CidadeNova.Nome && Ci.Estado == CidadeNova.Estado);
			if (Contem != null)
			{
				return BadRequest();
			}
			Contexto.Cidades.Add(CidadeNova);
			Contexto.SaveChanges();
			return CreatedAtAction(nameof(RetornaCidadePorId), new { Id = CidadeNova.Id }, CidadeDTO);
		}
		[HttpGet]
		public IActionResult RetornaTodosAsCidades()
		{
			IEnumerable<Cidade> TodasAsCidades = Contexto.Cidades;
			var TodasAsCidadesDTO = mapper.Map<IEnumerable<RetornaCidadeDTO>>(TodasAsCidades);
			return Ok(TodasAsCidadesDTO);
		}

		[HttpGet("{id}")]
		public IActionResult RetornaCidadePorId(Guid Id)
		{
			Cidade CidadePorId = Contexto.Cidades.FirstOrDefault(Ci => Ci.Id == Id);
			if(CidadePorId == null)
			{
				return NotFound();
			}
			var CidadePorIdDTO = mapper.Map<RetornaCidadeDTO>(CidadePorId);
			return Ok(CidadePorIdDTO);
		}

		[HttpDelete("{id}")]
		public IActionResult DeletaCidadePorId(Guid Id)
		{
			Cidade CidadeDoDb = Contexto.Cidades.FirstOrDefault(Ci => Ci.Id == Id);
			if (CidadeDoDb == null)
			{
				return NotFound();
			}
			Console.WriteLine(CidadeDoDb.Id);
			List<Cliente> ClientesRetornados = Contexto.Clientes.Where(C => EF.Property<Guid>(C, "CidadeId") == CidadeDoDb.Id).ToList();
			if (ClientesRetornados.Count > 0)
			{
				return BadRequest();
			}
			Contexto.Remove(CidadeDoDb);
			Contexto.SaveChanges();
			return NoContent();
		}

		[HttpPut("{id}")]
		public IActionResult EditaCidadePorId(Guid Id, [FromBody] EditaCidadeDTO CidadeDTO)
		{
			Cidade CidadeDoDb = Contexto.Cidades.FirstOrDefault(Ci => Ci.Id == Id);
			if(CidadeDoDb == null)
			{
				return NotFound();
			}
			mapper.Map(CidadeDTO, CidadeDoDb);
			Contexto.SaveChanges();
			return NoContent();
		}


	}
}
