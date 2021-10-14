using API_CidadesClientes.Models.DTOs.CidadeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Models.DTOs.ClienteDTOs
{
	public class RetornaClienteDTO
	{
		public string Nome { get; set; }
		public DateTime? DataDeNascimento { get; set; }
		public RetornaCidadeDTO cidade { get; set; }
		public string CEP { get; set; }
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
	}
}
