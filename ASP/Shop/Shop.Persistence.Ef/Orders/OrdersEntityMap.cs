using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Orders;

namespace Shop.Persistence.Ef.Orders;

public class OrdersEntityMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Customer).WithMany(_ => _.Orders)
            .HasForeignKey(_ => _.CustomerId);
    }
}