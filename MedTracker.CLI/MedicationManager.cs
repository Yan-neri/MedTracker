namespace MedTracker.CLI;

public class MedicationManager
{
    private readonly List<Medication> _medications = new();

    // Adiciona o remédio, mas aplica a dor real que estamos resolvendo!
    public void AddMedication(string name, string dosage, DateTime expiryDate, DateTime currentDate, string endereco = "Não informado")
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do medicamento não pode estar vazio.");

        if (expiryDate.Date < currentDate.Date)
            throw new ArgumentException("A data de validade não pode ser anterior à data atual.");

        // Agora passamos o 'endereco' para o construtor do Medication
        var medication = new Medication(name, dosage, expiryDate, endereco);

        _medications.Add(medication);
    }

    // Devolve a lista de todos os remédios
    public IReadOnlyList<Medication> GetAll()
    {
        return _medications.AsReadOnly();
    }

    // O Alerta: Pega apenas os remédios que vencem em 7 dias ou menos
    public IEnumerable<Medication> GetExpiredOrCloseToExpiry(DateTime currentDate)
    {
        return _medications.Where(m => (m.ExpiryDate.Date - currentDate.Date).TotalDays <= 7);
    }
}