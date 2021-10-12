using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Models
{
	public class Cidade
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public Estado estado { get; set; }
		public IList<Cliente> clientes { get; set; }
	}
}
