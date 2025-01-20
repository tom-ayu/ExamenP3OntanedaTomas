using ExamenP3OntanedaTomas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3OntanedaTomas.Repositories
{
    public class PaisAPIRespository
    {
        public string _url = "https://restcountries.com/v3.1/name/";

        public IEnumerable<Pais> DevuelvePais(string prompt)
        {
            string urlFinal = _url + prompt + "?fields=name,region,maps";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetAsync(urlFinal).Result;
                    var json_data = response.Content.ReadAsStringAsync().Result;

                    List<Pais> estudiantesAPI = JsonConvert.DeserializeObject<List<Pais>>(json_data);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return new List<Pais>();
        }

        internal bool DevuelvePais()
        {
            throw new NotImplementedException();
        }
    }
}
