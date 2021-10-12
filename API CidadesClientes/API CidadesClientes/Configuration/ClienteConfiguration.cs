using API_CidadesClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Configuration
{
	public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.
				ToTable("Clientes");

			builder
				.Property(C => C.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.IsRequired();

			builder
				.Property(C => C.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)")
				.IsRequired();

			builder
				.Property(C => C.DataDeNascimento)
				.HasColumnName("DataDeNascimento")
				.HasColumnType("datetime");

			builder
				.Property<Guid>("CidadeId").IsRequired();

			builder
				.HasOne(CL => CL.cidade)
				.WithMany(Ci => Ci.clientes)
				.HasForeignKey("CidadeId");
				
			builder
				.Property(C => C.CEP)
				.HasColumnName("CEP")
				.HasColumnType("varchar(20)")
				.IsRequired();

			builder
				.Property(C => C.Logradouro)
				.HasColumnName("Logradouro")
				.HasColumnType("varchar(max)");

			builder
				.Property(C => C.Bairro)
				.HasColumnName("Bairro")
				.HasColumnType("varchar(20)");
			
		}
	}
}
