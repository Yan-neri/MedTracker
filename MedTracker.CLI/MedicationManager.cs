namespace MedTracker.CLI;

public class MedicationManager
{
    private readonly List<Medication> _medications = new();

    // Adiciona o remédio, mas aplica a dor real que estamos resolvendo!
    public void AddMedication(string name, string dosage, DateTime expiryDate, DateTime currentDate)
    {
        // Regra 1: Não pode ter nome vazio
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("O nome do medicamento não pode ser vazio.");
        }

        // Regra 2: Não pode cadastrar remédio que já venceu no passado
        if (expiryDate.Date < currentDate.Date)
        {
            throw new ArgumentException("Não é permitido cadastrar medicamentos já vencidos.");
        }

        var medication = new Medication(name, dosage, expiryDate);
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