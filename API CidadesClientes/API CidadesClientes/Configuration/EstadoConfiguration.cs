using API_CidadesClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Configuration
{
	public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
	{
		public void Configure(EntityTypeBuilder<Estado> builder)
		{
			builder.
				ToTable("Estados");

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
		}
	}
}
