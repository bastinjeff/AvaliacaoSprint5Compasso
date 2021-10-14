using API_CidadesClientes.Models;
using API_CidadesClientes.Models.DTOs.ClienteDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Profiles
{
	public class ClienteProfile : Profile
	{
		public ClienteProfile()
		{
			CreateMap<RecebeClienteDTO, Cliente>();
			CreateMap<EditaClienteDTO, Cliente>();
			CreateMap<Cliente, RetornaClienteDTO>();
		}
	}
}
