using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence.Trips;

public class TripEntityMap : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable("Trips");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.HasOne(_ => _.Bus)
            .WithMany(_ => _.Trips)
            .HasForeignKey(_ => _.BusId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}