using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

// Configurar a leitura do appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Console.WriteLine("🧪 Testando conexão com SQL Server...");

// Pegar connection string do appsettings.json
string connectionString = configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("❌ Connection string não encontrada no appsettings.json");
    Console.WriteLine("💡 Verifique se a chave 'DefaultConnection' existe");
    return;
}

try
{
    using var connection = new SqlConnection(connectionString);
    
    Console.WriteLine("Conectando...");
    await connection.OpenAsync();
    
    Console.WriteLine("✅ CONEXÃO BEM-SUCEDIDA!");
    Console.WriteLine($"Versão do SQL Server: {connection.ServerVersion}");
    
    // Teste simples
    using var command = new SqlCommand("SELECT @@VERSION as versao", connection);
    var result = await command.ExecuteScalarAsync();
    
    Console.WriteLine($"📋 Versão detalhada: {result}");
    
    // Listar alguns databases
    Console.WriteLine("\n🗃️ Alguns databases disponíveis:");
    using var command2 = new SqlCommand(@"
        SELECT name, state_desc 
        FROM sys.databases 
        WHERE name IN ('master', 'model', 'msdb', 'tempdb')
        ORDER BY name", connection);
    
    using var reader = await command2.ExecuteReaderAsync();
    while (await reader.ReadAsync())
    {
        Console.WriteLine($" - {reader.GetString(0)} ({reader.GetString(1)})");
    }
    
    Console.WriteLine("\n🎉 CONEXÃO FUNCIONANDO PERFEITAMENTE!");
}
catch (SqlException ex)
{
    Console.WriteLine($"❌ ERRO SQL: {ex.Message}");
    Console.WriteLine($"Número do erro: {ex.Number}");
    
    switch (ex.Number)
    {
        case -2:
            Console.WriteLine("💡 Timeout - servidor pode não estar respondendo");
            break;
        case 53:
        case 40:
            Console.WriteLine("💡 Não encontrou o servidor SQL");
            Console.WriteLine("   • Verifique se o SQL Server está rodando");
            Console.WriteLine("   • Tente: Services.msc → Inicie o 'SQL Server'");
            break;
        case 18456:
            Console.WriteLine("💡 Erro de login - verifique usuário/senha");
            break;
        default:
            Console.WriteLine("💡 Consulte o número do erro para mais detalhes");
            break;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ ERRO: {ex.Message}");
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();