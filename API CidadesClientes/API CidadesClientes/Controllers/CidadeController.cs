using API_CidadesClientes.Models.DTOs.CidadeDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CidadeController : ControllerBase
	{

		[HttpGet]
		public void RetornaTodosAsCidades()
		{

		}

		[HttpGet("{id}")]
		public void RetornaCidadePorId(int Id)
		{

		}

		[HttpDelete("{id}")]
		public void DeletaCidadePorId(int Id)
		{

		}

		[HttpPut("id")]
		public void EditaCidadePorId(int Id, [FromBody] EditaCidadeDTO CidadeDTO)
		{

		}


	}
}
