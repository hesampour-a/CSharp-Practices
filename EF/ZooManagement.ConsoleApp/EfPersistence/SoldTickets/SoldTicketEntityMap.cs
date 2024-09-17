using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.SoldTickets;

public class SoldTicketEntityMap : IEntityTypeConfiguration<SoldTicket>
{
    public void Configure(EntityTypeBuilder<SoldTicket> builder)
    {
        builder.ToTable("SoldTickets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Ticket).WithMany(_ => _.SoldTickets)
            .HasForeignKey(_ => _.TicketId);
    }
}