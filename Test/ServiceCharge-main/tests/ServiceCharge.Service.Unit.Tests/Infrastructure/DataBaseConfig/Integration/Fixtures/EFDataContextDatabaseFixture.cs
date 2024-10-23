using ServiceCharge.Persistence.Ef;

namespace ServiceCharge.Service.Unit.Tests.Infrastructure.DataBaseConfig.Integration.
    Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    protected static EfDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;
        

        return new EfDataContext(
            $"server=.;database=BlocksDb;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;");
    }
}