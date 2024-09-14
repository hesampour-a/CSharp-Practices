using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Customers;

public class CustomerEntityMap :IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
       builder.ToTable("Customers");
       builder.HasKey(x => x.Id);
       builder.Property(x => x.Id).UseIdentityColumn();
    }
}