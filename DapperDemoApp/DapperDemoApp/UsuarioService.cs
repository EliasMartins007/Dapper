//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//public class UsuarioService
//{
//    private readonly HttpClient _httpClient;

//    public UsuarioService()
//    {
//        _httpClient = new HttpClient();
//        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
//        _httpClient.DefaultRequestHeaders.Accept.Clear();
//        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//    }

//    public async Task<string> ObterUsuariosAsync()
//    {
//        HttpResponseMessage response = await _httpClient.GetAsync("users");
//        if (response.IsSuccessStatusCode)
//        {
//            string dados = await response.Content.ReadAsStringAsync();
//            return dados;
//        }
//        else
//        {
//            return "Erro ao chamar a API.";
//        }
//    }
//}



///

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


//