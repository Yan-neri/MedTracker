using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MedTracker.CLI;

public class ViaCepService
{
    private readonly HttpClient _httpClient = new HttpClient();

    public async Task<string> BuscarEnderecoPorCep(string cep)
    {
        try
        {
            // Limpa o CEP caso o usuário digite com traço
            cep = cep.Replace("-", "").Trim();
            
            if (cep.Length != 8) return "CEP inválido.";

            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var response = await _httpClient.GetFromJsonAsync<ViaCepResponse>(url);

            if (response == null || !string.IsNullOrEmpty(response.erro))
            {
                return "Endereço não encontrado.";
            }

            return $"{response.logradouro}, {response.bairro}, {response.localidade}-{response.uf}";
        }
        catch
        {
            return "Erro de conexão com a API.";
        }
    }
}

public class ViaCepResponse
{
    public string? logradouro { get; set; }
    public string? bairro { get; set; }
    public string? localidade { get; set; }
    public string? uf { get; set; }
    public string? erro { get; set; }
}