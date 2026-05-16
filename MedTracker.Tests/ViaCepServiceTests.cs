using Xunit;
using MedTracker.CLI;
using System.Threading.Tasks;

namespace MedTracker.Tests;

public class ViaCepServiceTests
{
    [Fact]
    public async Task BuscarEndereco_DeveRetornarEnderecoCorreto_ParaCepValido()
    {

        var servico = new ViaCepService();
        var cepValido = "01001000";


        var resultado = await servico.BuscarEnderecoPorCep(cepValido);


        Assert.Contains("Praça da Sé", resultado);
        Assert.Contains("SP", resultado);
    }

    [Fact]
    public async Task BuscarEndereco_DeveRetornarErro_ParaCepInvalido()
    {

        var servico = new ViaCepService();
        var cepInvalido = "00000000";


        var resultado = await servico.BuscarEnderecoPorCep(cepInvalido);


        Assert.Equal("Endereço não encontrado.", resultado);
    }
}