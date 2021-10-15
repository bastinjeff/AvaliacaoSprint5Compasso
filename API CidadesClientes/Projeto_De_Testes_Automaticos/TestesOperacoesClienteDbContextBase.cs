using API_CidadesClientes.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_De_Testes_Automaticos
{
	public abstract class TestesOperacoesClienteDbContextBase
	{
		protected DbContextOptions<ClienteDbContext> options;
		protected ClienteDbContext Contexto;
		public TestesOperacoesClienteDbContextBase()
		{
			options = new DbContextOptionsBuilder<ClienteDbContext>()
				.UseInMemoryDatabase("ClienteDbContext")
				.Options;
			Contexto = new ClienteDbContext(options);									
		}
	}
}
