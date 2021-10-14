using API_CidadesClientes.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API_CidadesClientes
{
	public static class OperacoesViaCEP
	{
		public static RecebeCidadeViaCepDTO RetornaObjetoViaCep(string CEP)
		{
			var Resultado = BuscaEnderecoViaCep(CEP);
			var ViaCepData = JsonConvert.DeserializeObject<RecebeCidadeViaCepDTO>(Resultado);
			return ViaCepData;
		}
		private static string BuscaEnderecoViaCep(string CEP)
		{
			var ViaCepURL = $"http://www.viacep.com.br/ws/{CEP}/json/";
			var Requisicao = WebRequest.Create(ViaCepURL);
			Requisicao.Method = "GET";
			using var Resposta = Requisicao.GetResponse();
			using var Stream = Resposta.GetResponseStream();
			using var Leitor = new StreamReader(Stream);
			var JsonViaCep = Leitor.ReadToEnd();
			return JsonViaCep;
		}
	}
}
