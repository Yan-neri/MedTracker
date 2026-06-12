using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using System;

namespace MedTracker.CLI;

public class MedTrackerDbContext : DbContext
{
    private readonly string _connectionString;

    public MedTrackerDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Mapeia a sua entidade Medication para a tabela no banco
    public DbSet<Medication> Medications { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}

// Esta Factory permite que a ferramenta 'dotnet ef' encontre a base de dados
public class MedTrackerDbContextFactory : IDesignTimeDbContextFactory<MedTrackerDbContext>
{
    public MedTrackerDbContext CreateDbContext(string[] args)
    {
        // Volta a carregar a partir do ficheiro .env seguro
        Env.Load();
        string connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING") ?? "";

        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("A string de conexão não foi encontrada no ficheiro .env.");

        return new MedTrackerDbContext(connectionString);
    }
}