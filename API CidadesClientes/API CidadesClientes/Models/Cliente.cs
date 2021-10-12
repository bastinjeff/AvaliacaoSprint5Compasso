using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Models
{
	public class Cliente
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public DateTime? DataDeNascimento { get; set; }
		public Cidade cidade { get; set; }
		public string CEP { get; set; }
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
	}
}
