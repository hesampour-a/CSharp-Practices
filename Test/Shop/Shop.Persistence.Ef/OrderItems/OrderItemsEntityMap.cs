using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.OrderItems;

namespace Shop.Persistence.Ef.OrderItems;

public class OrderItemsEntityMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Count).IsRequired();
        builder.HasOne(_ => _.Order).WithMany(_ => _.OrderItems)
            .HasForeignKey(_ => _.OrderId);
        builder.HasOne(_ => _.Product).WithMany(_ => _.OrderItems)
            .HasForeignKey(_ => _.ProductId);
    }
}