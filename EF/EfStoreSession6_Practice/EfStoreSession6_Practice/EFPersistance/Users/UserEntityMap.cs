using EfStoreSession6_Practice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfStoreSession6_Practice.EFPersistance.Users;

public class UserEntityMap:IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .UseIdentityColumn();
        builder.Property(_ => _.FirstName)
            .IsRequired().HasMaxLength(100);
        builder.Property(_ => _.LastName)
            .IsRequired().HasMaxLength(100);
        builder.Property(_ => _.PhoneNumber)
            .IsRequired().HasMaxLength(10);
    }
}