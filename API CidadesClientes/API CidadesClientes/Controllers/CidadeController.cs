using API_CidadesClientes.Contextos;
using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs.CidadeDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
		[HttpGet]
		public void RetornaTodosAsCidades()
		{

		}

		[HttpGet("{id}")]
		public void RetornaCidadePorId(int Id)
		{

		}

		[HttpDelete("{id}")]
		public IActionResult DeletaCidadePorId(Guid Id)
		{
			Cidade CidadeDoDb = Contexto.Cidades.FirstOrDefault(Ci => Ci.Id == Id);
			if (CidadeDoDb == null)
			{
				return NotFound();
			}
			Contexto.Remove(CidadeDoDb);
			Contexto.SaveChanges();
			return NoContent();
		}

		[HttpPut("id")]
		public void EditaCidadePorId(int Id, [FromBody] EditaCidadeDTO CidadeDTO)
		{

		}


	}
}
