using Xunit;
using MedTracker.CLI; // Conecta com o seu projeto principal
using System.Threading.Tasks;

namespace MedTracker.Tests;

public class ViaCepServiceTests
{
    [Fact]
    public async Task BuscarEndereco_DeveRetornarEnderecoCorreto_ParaCepValido()
    {
        // Arrange: Prepara o terreno com um CEP que sabemos que existe
        var servico = new ViaCepService();
        var cepValido = "01001000"; // CEP da Praça da Sé, São Paulo

        // Act: Roda a busca na API
        var resultado = await servico.BuscarEnderecoPorCep(cepValido);

        // Assert: Verifica se a API devolveu o que a gente esperava
        Assert.Contains("Praça da Sé", resultado);
        Assert.Contains("SP", resultado);
    }

    [Fact]
    public async Task BuscarEndereco_DeveRetornarErro_ParaCepInvalido()
    {
        // Arrange: Prepara um CEP falso
        var servico = new ViaCepService();
        var cepInvalido = "00000000";

        // Act: Roda a busca
        var resultado = await servico.BuscarEnderecoPorCep(cepInvalido);

        // Assert: Verifica se o sistema barrou direitinho
        Assert.Equal("Endereço não encontrado.", resultado);
    }
}