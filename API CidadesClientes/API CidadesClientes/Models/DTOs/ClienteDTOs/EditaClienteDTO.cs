using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Models.DTOs.ClienteDTOs
{
	public class EditaClienteDTO
	{
		public string Nome { get; set; }
		public DateTime? DataDeNascimento { get; set; }
		public string CEP { get; set; }

	}
}
