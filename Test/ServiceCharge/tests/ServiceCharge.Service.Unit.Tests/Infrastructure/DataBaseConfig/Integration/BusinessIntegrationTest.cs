using ServiceCharge.Persistence.Ef;
using ServiceCharge.Service.Unit.Tests.Infrastructure.DataBaseConfig.Integration.Fixtures;

namespace ServiceCharge.Service.Unit.Tests.Infrastructure.DataBaseConfig.Integration;

public class BusinessIntegrationTest : EFDataContextDatabaseFixture
{
    protected EfDataContext Context { get; init; }
    protected EfDataContext SetupContext { get; init; }
    protected EfDataContext ReadContext { get; init; }
    protected string TenantId { get; } = "Tenant_Id";
    
    protected BusinessIntegrationTest(string? tenantId = null)
    {
        if (tenantId != null)
        {
            TenantId = tenantId;
        }

        SetupContext = CreateDataContext(TenantId);
        Context = CreateDataContext(TenantId);
        ReadContext = CreateDataContext(TenantId);
    }
    protected void Save<T>(T entity)
        where T : class
    {
        Context.Manipulate(_ => _.Add(entity));
    }

    protected void Save<T>(params T[] entities) 
        where T : class
    {
        foreach (var entity in entities)
        {
            Context.Save(entity);
        }
    }
}