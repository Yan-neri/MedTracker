using MedTracker.CLI;
using Xunit;

namespace MedTracker.Tests;

public class MedicationManagerTests
{
    // Teste 1 (Caminho Feliz): Cadastrar um remédio válido
    [Fact]
    public void AddMedication_ValidData_ShouldAddToList()
    {
        // Preparação (Arrange)
        var manager = new MedicationManager();
        var today = new DateTime(2026, 3, 21);
        var expiryDate = new DateTime(2026, 12, 31);

        // Ação (Act)
        manager.AddMedication("Paracetamol", "500mg", expiryDate, today);

        // Verificação (Assert)
        Assert.Single(manager.GetAll()); // Garante que tem exatamente 1 item na lista
        Assert.Equal("Paracetamol", manager.GetAll()[0].Name);
    }

    // Teste 2 (Entrada Inválida): Tentar cadastrar sem nome
    [Fact]
    public void AddMedication_EmptyName_ShouldThrowException()
    {
        var manager = new MedicationManager();
        var today = new DateTime(2026, 3, 21);
        var expiryDate = new DateTime(2026, 12, 31);

        // Ação e Verificação
        var exception = Assert.Throws<ArgumentException>(() => 
            manager.AddMedication("", "500mg", expiryDate, today));
            
        Assert.Equal("O nome do medicamento não pode ser vazio.", exception.Message);
    }

    // Teste 3 (Regra de Negócio): Tentar cadastrar remédio que já venceu
    [Fact]
    public void AddMedication_ExpiredDate_ShouldThrowException()
    {
        var manager = new MedicationManager();
        var today = new DateTime(2026, 3, 21);
        var pastDate = new DateTime(2025, 1, 1); // Uma data no passado

        // Ação e Verificação
        var exception = Assert.Throws<ArgumentException>(() => 
            manager.AddMedication("Aspirina", "100mg", pastDate, today));

        Assert.Equal("Não é permitido cadastrar medicamentos já vencidos.", exception.Message);
    }
}