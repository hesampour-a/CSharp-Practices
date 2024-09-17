using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence.Tickets;

public class TicketEntityMap : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Trip).WithMany(_ => _.Tickets)
            .HasForeignKey(_ => _.TripId);
        builder.HasOne(_ => _.User).WithMany(_ => _.Tickets)
            .HasForeignKey(_ => _.UserId);
    }
}