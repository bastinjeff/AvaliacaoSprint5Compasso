using API_CidadesClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Configuration
{
	public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
	{
		public void Configure(EntityTypeBuilder<Cidade> builder)
		{
			builder.
				ToTable("Cidades");

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
				.Property(C => C.Estado)
				.HasColumnName("Estado")
				.HasColumnType("varchar(max)")
				.IsRequired();
		}
	}
}
