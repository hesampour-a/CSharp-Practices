using EfStoreSession6_Practice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfStoreSession6_Practice.EFPersistance.Employees;

public class EmployeeEntityMap:IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Staffs");
        
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .UseIdentityColumn();
        builder.Property(_ => _.UserId)
            .IsRequired();
        builder
            .Property(_ => _.PersonnelNumber)
            .IsRequired().HasMaxLength(10);
        builder.Property(_ => _.StoreId)
            .IsRequired(false);
    }
}