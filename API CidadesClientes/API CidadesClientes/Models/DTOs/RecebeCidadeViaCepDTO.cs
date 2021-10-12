using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CidadesClientes.Models.DTOs
{
	public class RecebeCidadeViaCepDTO
	{
		/*"cep": "01001-000",
      "logradouro": "Praça da Sé",
      "complemento": "lado ímpar",
      "bairro": "Sé",
      "localidade": "São Paulo",
      "uf": "SP",
      "ibge": "3550308",
      "gia": "1004",
      "ddd": "11",
      "siafi": "7107"*/

		public string cep { get; set; }
		public string logradouro { get; set; }
		public string complemento { get; set; }
		public string bairro { get; set; }
		public string localidade { get; set; }
		public string uf { get; set; }
		public string ibge { get; set; }
		public string gia { get; set; }
		public string ddd { get; set; }
		public string siafi { get; set; }
	}
}
