using API_CidadesClientes.Contextos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Controllers
{
	public abstract class MainController : ControllerBase
	{
		protected ClienteDbContext Contexto;
		protected IMapper mapper;
		public MainController(ClienteDbContext Contexto, IMapper mapper)
		{
			this.Contexto = Contexto;
			this.mapper = mapper;
		}
	}
}
