using System.Text.Json;

namespace CepApi.Domain.Api.Utils
{
    public class HttpConnection
    {
        private readonly HttpClient _httpClient;

        public HttpConnection(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://viacep.com.br/");
        }

        public async Task<string> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            if(response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(responseBody);

                if(jsonDoc.RootElement.TryGetProperty("erro", out var errorElement))
                {
                    string erroValue = errorElement.GetString();
                    if (string.Equals(erroValue, "true", StringComparison.OrdinalIgnoreCase))
                    {
                        return "";
                    }
                }

               return responseBody;
            }

            return "";
        }
    }
}
