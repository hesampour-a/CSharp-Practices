using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Products;

public class ProductEntityMap :IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
    }
}