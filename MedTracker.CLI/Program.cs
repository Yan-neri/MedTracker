using MedTracker.CLI;

// 1. Instanciamos o serviço de CEP aqui no topo
var manager = new MedicationManager();
var viaCepService = new ViaCepService(); 
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
            string dataInput = Console.ReadLine() ?? "";

            // --- NOVA PARTE DO CEP COMEÇA AQUI ---
            Console.Write("CEP da farmácia (apenas números) ou Enter para pular: ");
            string cep = Console.ReadLine() ?? "";
            string endereco = "Não informado";

            if (!string.IsNullOrWhiteSpace(cep))
            {
                Console.WriteLine("🔍 Consultando endereço...");
                // Usamos 'await' para esperar a resposta da API
                endereco = await viaCepService.BuscarEnderecoPorCep(cep);
                Console.WriteLine($"📍 Endereço: {endereco}");
            }
            // --- NOVA PARTE DO CEP TERMINA AQUI ---

            if (DateTime.TryParse(dataInput, out DateTime expiryDate))
            {
                try
                {
                    // Agora passamos o 'endereco' para o método de adicionar
                    manager.AddMedication(name, dosage, expiryDate, DateTime.Now, endereco);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Medicamento cadastrado com sucesso!");
                    Console.ResetColor();
                }
                catch (ArgumentException ex)
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
                // Adicionamos a exibição do endereço na listagem
                Console.WriteLine($"- {med.Name} ({med.Dosage})");
                Console.WriteLine($"  Validade: {med.ExpiryDate:dd/MM/yyyy} | Farmácia: {med.EnderecoFarmacia}");
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