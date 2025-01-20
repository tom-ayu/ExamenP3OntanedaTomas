using ExamenP3OntanedaTomas.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamenP3OntanedaTomas.Repositories
{
    public class PaisAPIRepository
    {
        public string _url = "https://restcountries.com/v3.1/name/";

        public async Task<IEnumerable<Pais>> DevuelvePaisAsync(string prompt)
        {
            string urlFinal = $"{_url}{prompt}?fields=name,region,maps";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(urlFinal);
                    var json_data = await response.Content.ReadAsStringAsync();
                    List<Pais> paisAPI = JsonConvert.DeserializeObject<List<Pais>>(json_data);
                    return paisAPI;
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine($"Error solicitud HTTP: {httpEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
                return new List<Pais>();
            }
        }
    }

}
