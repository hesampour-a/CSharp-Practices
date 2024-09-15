using BuildingManagement.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManagement.ConsoleApp.EfPersistence.Costs;

public class CostEntityMap : IEntityTypeConfiguration<Cost>
{
    public void Configure(EntityTypeBuilder<Cost> builder)
    {
        builder.ToTable("Costs");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Block).WithMany(_ => _.Costs)
            .HasForeignKey(_ => _.BlockId);
    }
}