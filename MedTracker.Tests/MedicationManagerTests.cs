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
        // Arrange
        var manager = new MedicationManager();

        // Act
        var ex = Assert.Throws<ArgumentException>(() =>
            manager.AddMedication("", "500mg", DateTime.Now.AddDays(10), DateTime.Now)
        );

        // Assert (Atenção ao ex.Message com 'M' maiúsculo)
        Assert.Equal("O nome do medicamento não pode estar vazio.", ex.Message);
    }

    [Fact]
    public void AddMedication_ExpiredDate_ShouldThrowException()
    {
        // Arrange
        var manager = new MedicationManager();

        // Act
        var ex = Assert.Throws<ArgumentException>(() =>
            manager.AddMedication("Aspirina", "500mg", DateTime.Now.AddDays(-5), DateTime.Now)
        );

        // Assert
        Assert.Equal("A data de validade não pode ser anterior à data atual.", ex.Message);
    }
}