namespace MedTracker.CLI;

public class MedicationManager
{
    private readonly List<Medication> _medications = new();


    public void AddMedication(string name, string dosage, DateTime expiryDate, DateTime currentDate, string endereco = "Não informado")
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do medicamento não pode estar vazio.");

        if (expiryDate.Date < currentDate.Date)
            throw new ArgumentException("A data de validade não pode ser anterior à data atual.");


        var medication = new Medication(name, dosage, expiryDate, endereco);

        _medications.Add(medication);
    }


    public IReadOnlyList<Medication> GetAll()
    {
        return _medications.AsReadOnly();
    }


    public IEnumerable<Medication> GetExpiredOrCloseToExpiry(DateTime currentDate)
    {
        return _medications.Where(m => (m.ExpiryDate.Date - currentDate.Date).TotalDays <= 7);
    }
}