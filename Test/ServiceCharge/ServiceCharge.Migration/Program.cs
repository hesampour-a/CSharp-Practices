using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Migration;

internal class Program
{
    private static readonly string _dbName = "BlocksDb";

    private static readonly string _connectionStringWithoutDatabase =
        "server=.;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;";

    private static readonly string _connectionString =
        $"server=.;database={_dbName};Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;";

    private static void EnsureDatabaseExists(string dbName,
        string connectionString)
    {
        var createDbQuery =
            $"IF DB_ID('{dbName}') IS NULL CREATE DATABASE {dbName}";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand(createDbQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    private static void Main(string[] args)
    {
        EnsureDatabaseExists(_dbName, _connectionStringWithoutDatabase);
        using (var serviceProvider = CreateServices())
        using (var scope = serviceProvider.CreateScope())
        {
            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            UpdateDatabase(scope.ServiceProvider);
        }
    }

    /// <summary>
    ///     Configure the dependency injection services
    /// </summary>
    private static ServiceProvider CreateServices()
    {
        return new ServiceCollection()
            // Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                // Add SQLite support to FluentMigrator
                .AddSqlServer()
                // Set the connection string
                .WithGlobalConnectionString(_connectionString)
                // Define the assembly containing the migrations
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            // Enable logging to console in the FluentMigrator way
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            // Build the service provider
            .BuildServiceProvider(false);
    }

    /// <summary>
    ///     Update the database
    /// </summary>
    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        // Instantiate the runner
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        // Execute the migrations
        runner.MigrateUp();
    }
}