using MedTracker.CLI;

var manager = new MedicationManager();
bool running = true;

Console.WriteLine("=====================================");
Console.WriteLine("      💊 Bem-vindo ao MedTracker     ");
Console.WriteLine(" Seu assistente de controle de saúde ");
Console.WriteLine("=====================================");

while (running)
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine("1. Cadastrar Medicamento");
    Console.WriteLine("2. Listar Todos os Medicamentos");
    Console.WriteLine("3. Verificar Alertas de Vencimento");
    Console.WriteLine("4. Sair");
    Console.Write("Opção: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("\nNome do medicamento: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Dosagem (ex: 500mg, 1 comprimido): ");
            string dosage = Console.ReadLine() ?? "";

            Console.Write("Data de Validade (DD/MM/AAAA): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime expiryDate))
            {
                try
                {
                    manager.AddMedication(name, dosage, expiryDate, DateTime.Now);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Medicamento cadastrado com sucesso!");
                    Console.ResetColor();
                }
                catch (ArgumentException ex) // Captura os erros que criamos lá na regra de negócio
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Erro: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Erro: Formato de data inválido. Use DD/MM/AAAA.");
                Console.ResetColor();
            }
            break;

        case "2":
            Console.WriteLine("\n--- Todos os Medicamentos ---");
            var meds = manager.GetAll();
            if (!meds.Any()) Console.WriteLine("Nenhum medicamento cadastrado no momento.");

            foreach (var med in meds)
            {
                Console.WriteLine($"- {med.Name} ({med.Dosage}) | Validade: {med.ExpiryDate:dd/MM/yyyy}");
            }
            break;

        case "3":
            Console.WriteLine("\n--- Alertas de Vencimento ---");
            var expiring = manager.GetExpiredOrCloseToExpiry(DateTime.Now);

            if (!expiring.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Tudo certo! Nenhum medicamento vencendo nos próximos 7 dias.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("⚠️ ATENÇÃO! Os seguintes medicamentos estão vencidos ou próximos do vencimento:");
                foreach (var med in expiring)
                {
                    Console.WriteLine($"- {med.Name} | Validade: {med.ExpiryDate:dd/MM/yyyy}");
                }
                Console.ResetColor();
            }
            break;

        case "4":
            running = false;
            Console.WriteLine("\nEncerrando o MedTracker. Cuide-se!");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}
