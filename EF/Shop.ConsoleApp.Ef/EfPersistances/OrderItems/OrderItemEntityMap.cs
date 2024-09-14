using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.OrderItems;

public class OrderItemEntityMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
    }
}