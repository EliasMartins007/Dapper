
using System.Net.Http;
using System.Threading.Tasks;
namespace DapperDemoApp

{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ObterUsuariosAsync()
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/users"; // API pública para exemplo
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode(); // Lança exceção se status não for sucesso

                string json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (HttpRequestException ex)
            {
                return $"Erro na requisição: {ex.Message}";
            }
        }
    }
}
