using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs.CidadeDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Profiles
{
	public class CidadeProfile : Profile
	{
		public CidadeProfile()
		{
			CreateMap<Cidade, RetornaCidadeDTO>();
			CreateMap<EditaCidadeDTO, Cidade>();
			CreateMap<RecebeCidadeDTO, Cidade>();
		}
	}
}
