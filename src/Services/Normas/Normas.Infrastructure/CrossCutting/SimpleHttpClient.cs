using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIGO.Normas.Infrastructure.CrossCutting
{
    public class SimpleHttpClient
    {
        private readonly HttpClient _httpClient;

        public SimpleHttpClient()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetRequest(string endpointPath)
        {
            // Make the request
            HttpResponseMessage response = _httpClient.
                                           GetAsync(endpointPath).
                                           Result;
            if (!response.IsSuccessStatusCode)
                throw new ArgumentException($"O caminho {endpointPath} retorna o seguinte status code: " + response.StatusCode);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
