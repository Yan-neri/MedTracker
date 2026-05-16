namespace MedTracker.CLI;

public class Medication
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Dosage { get; private set; }
    public DateTime ExpiryDate { get; private set; }
    public string EnderecoFarmacia { get; set; }


    public Medication(string name, string dosage, DateTime expiryDate, string enderecoFarmacia = "Não informado")
    {
        Id = Guid.NewGuid();
        Name = name;
        Dosage = dosage;
        ExpiryDate = expiryDate;
        EnderecoFarmacia = enderecoFarmacia;
    }
}
