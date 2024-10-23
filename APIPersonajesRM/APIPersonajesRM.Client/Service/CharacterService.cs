using APIPersonajesRM.Client.Services;
using APIPersonajesRM.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIPersonajesRM.Client.Service
{
	public class CharacterService : ICharacterService
	{
		private readonly HttpClient _httpClient;

		public CharacterService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Characters> GetCharactersAsync()
		{
			try
			{
				var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/character");

				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<Characters>(responseBody);
				}
				else
				{
					Console.WriteLine("Error en la solicitud: " + response.StatusCode);
					return null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Excepción al obtener personajes: " + ex.Message);
				return null;
			}
		}
	}
}
