using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityFCore.Utils
{
    public class Moeda
    {
        // Moeda info é referente a USD
        [JsonPropertyName("USD")]
        public MoedaInfo MoedaInfo { get; set; }

        public float GetDolarValue()
        {
            // Dizemos o valor um antes de fazer a comunicação com a API, ao conectar com a API o valor é estabelecido por ela
            float dolarHoje = 1;

            using (var client = new HttpClient())
            {
                // URL
                client.BaseAddress = new System.Uri("https://economia.awesomeapi.com.br/");
                // Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Response                          // GET (action)
                HttpResponseMessage response = client.GetAsync("all/USD-BRL").Result;

                // Status Code
                if (response.IsSuccessStatusCode)
                {
                    // Body
                    string cotacao = response.Content.ReadAsStringAsync().Result;
                    Moeda convertido = JsonSerializer.Deserialize<Moeda>(cotacao);

                    
                    dolarHoje = float.Parse(convertido.MoedaInfo.Valor.Replace('.', ','));

                }
            }

            return dolarHoje;
        }
    }
    
    public class MoedaInfo
    {
        [JsonPropertyName("high")]
        public string Valor { get; set; }
    }
}
