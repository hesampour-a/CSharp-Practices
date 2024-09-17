using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Partitions;

public class PartitionEntityMap : IEntityTypeConfiguration<Partition>
{
    public void Configure(EntityTypeBuilder<Partition> builder)
    {
        builder.ToTable("Partitions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Animal).WithMany(_ => _.Partitions)
            .HasForeignKey(_ => _.AnimalId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}