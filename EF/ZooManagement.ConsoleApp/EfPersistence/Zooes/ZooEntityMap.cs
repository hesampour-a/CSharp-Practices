using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Zooes;

public class ZooEntityMap : IEntityTypeConfiguration<Zoo>
{
    public void Configure(EntityTypeBuilder<Zoo> builder)
    {
        builder.ToTable("Zooes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();
        builder.HasMany(_ => _.Partitions).WithOne(_ => _.Zoo)
            .HasForeignKey(_ => _.ZooId);
    }
}