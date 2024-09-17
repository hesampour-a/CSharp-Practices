using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Animals;

public class AnimalEntityMap : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals");
        builder.HasKey(x => x.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Title).IsRequired();
    }
}