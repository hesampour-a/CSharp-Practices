using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Orders;

public class OrderEntityMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(_ => _.TotalPrice).HasDefaultValue(0);
        builder.HasMany(_ => _.OrderItems).WithOne(_ => _.Order)
            .HasForeignKey(_ => _.OrderId).OnDelete(DeleteBehavior.NoAction);
    }
}