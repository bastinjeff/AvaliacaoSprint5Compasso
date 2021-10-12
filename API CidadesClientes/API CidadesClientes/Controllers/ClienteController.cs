using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs;
using System.Net;
using System.IO;

namespace API_CidadesClientes.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : ControllerBase
	{
		[HttpPost]
		public void RerecebeClienteJSON(RecebeClienteDTO ClienteNovo )
		{
			Console.WriteLine(ClienteNovo.CEP);
			var Resultado = OperacoesViaCEP.BuscaEnderecoViaCep(ClienteNovo.CEP);
		}

		
	}
}
