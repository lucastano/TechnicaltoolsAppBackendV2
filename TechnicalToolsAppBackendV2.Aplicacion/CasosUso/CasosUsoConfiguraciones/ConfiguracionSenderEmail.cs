using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoConfiguraciones
{
    public class ConfiguracionSenderEmail : IConfiguracionSenderEmail
    {
        private readonly HttpClient _httpClient;
        // por ahora va a estar hardcodeado pero se supone que esta info sale de configuracionMailJet
        private readonly string _apiKey;
        private readonly string _secretKey;

        public ConfiguracionSenderEmail(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = "61054e18304d8ea0c8771ad4b921581c";
            _secretKey = "43a216a71a806e6e3225eb24013ba5b7";
            var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_apiKey}:{_secretKey}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
        }

        public async void Ejecutar(string email)
        {
            var json = new
            {
                Email = email,
                Name = email
            };
            var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.mailjet.com/v3/REST/sender", content);
            var responseContent = await response.Content.ReadAsStringAsync();
        }
    }
}
