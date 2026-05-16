using MedTracker.CLI;
using Xunit;

namespace MedTracker.Tests;

public class MedicationManagerTests
{

    [Fact]
    public void AddMedication_ValidData_ShouldAddToList()
    {

        var manager = new MedicationManager();
        var today = new DateTime(2026, 3, 21);
        var expiryDate = new DateTime(2026, 12, 31);


        manager.AddMedication("Paracetamol", "500mg", expiryDate, today);


        Assert.Single(manager.GetAll());
        Assert.Equal("Paracetamol", manager.GetAll()[0].Name);
    }


    [Fact]
    public void AddMedication_EmptyName_ShouldThrowException()
    {

        var manager = new MedicationManager();


        var ex = Assert.Throws<ArgumentException>(() =>
            manager.AddMedication("", "500mg", DateTime.Now.AddDays(10), DateTime.Now)
        );


        Assert.Equal("O nome do medicamento não pode estar vazio.", ex.Message);
    }

    [Fact]
    public void AddMedication_ExpiredDate_ShouldThrowException()
    {

        var manager = new MedicationManager();


        var ex = Assert.Throws<ArgumentException>(() =>
            manager.AddMedication("Aspirina", "500mg", DateTime.Now.AddDays(-5), DateTime.Now)
        );


        Assert.Equal("A data de validade não pode ser anterior à data atual.", ex.Message);
    }
}