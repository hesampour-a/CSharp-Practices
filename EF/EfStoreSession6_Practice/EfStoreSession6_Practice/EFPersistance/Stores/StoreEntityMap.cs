using EfStoreSession6_Practice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfStoreSession6_Practice.EFPersistance.Stores;

public class StoreEntityMap : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Stores");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .UseIdentityColumn();
        builder.Property(_ => _.Name)
            .IsRequired().HasMaxLength(100);
    }
}