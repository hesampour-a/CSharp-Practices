using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Products;

namespace Shop.Persistence.Ef.Products;

public class ProductsEntityMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(_ => _.Title).IsRequired();
        builder.Property(_ => _.Price).IsRequired();
        builder.Property(_ => _.AvailableCount).IsRequired();
    }
}