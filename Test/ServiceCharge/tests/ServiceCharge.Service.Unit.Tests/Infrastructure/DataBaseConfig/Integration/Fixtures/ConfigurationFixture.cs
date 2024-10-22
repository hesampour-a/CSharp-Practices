using Microsoft.Extensions.Configuration;

namespace ServiceCharge.Service.Unit.Tests.Infrastructure.DataBaseConfig.Integration.Fixtures;

public class ConfigurationFixture
{
    public ConfigurationFixture()
    {
        Value = GetSettings();
    }

    public PersistenceConfig Value { get; }

    private PersistenceConfig GetSettings()
    {
        var settings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, false)
            .AddEnvironmentVariables()
            .AddCommandLine(Environment.GetCommandLineArgs())
            .Build();

        var testSettings = new PersistenceConfig();
        settings.Bind("PersistenceConfig", testSettings);
        return testSettings;
    }
}

public class PersistenceConfig
{
    public string ConnectionString { get; set; }
}

[CollectionDefinition(
    nameof(ConfigurationFixture),
    DisableParallelization = false)]
public class
    ConfigurationCollectionFixture : ICollectionFixture<
        ConfigurationFixture>
{
}