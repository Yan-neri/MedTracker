namespace MedTracker.CLI;

public class Medication
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Dosage { get; private set; }
    public DateTime ExpiryDate { get; private set; }

    public Medication(string name, string dosage, DateTime expiryDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Dosage = dosage;
        ExpiryDate = expiryDate;
    }
}