using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Models
{
	public class Estado
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public IList<Cidade> cidades { get; set; }
	}
}
