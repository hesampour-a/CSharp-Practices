using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Tickets;

public class TicketEntityMap : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Partition).WithOne(_ => _.Ticket)
            .HasForeignKey<Ticket>(_ => _.PartitionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}