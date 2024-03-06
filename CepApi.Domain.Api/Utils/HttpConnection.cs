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

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
