using Library.Persistence.Ef;

namespace Library.Services.Tests.Infrastructure.DataBaseConfig.Integration.
    Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    protected static EfDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;
        

        return new EfDataContext(
            connectionString);
    }
}