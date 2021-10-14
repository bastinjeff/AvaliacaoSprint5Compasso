using API_CidadesClientes.Configuration;
using API_CidadesClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Contextos
{
	public class ClienteDbContext : DbContext
	{
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Cidade> Cidades { get; set; }

		public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CidadeConfiguration());
			modelBuilder.ApplyConfiguration(new ClienteConfiguration());
		}
	}
}
