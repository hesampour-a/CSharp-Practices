using Library.Entities.Rates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Ef.Rates;

public class RateEntityMap : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("Rates");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(_ => _.Score).IsRequired();
        builder.HasOne(_ => _.Book).WithMany(_ => _.Rates)
            .HasForeignKey(_ => _.BookId);
    }
}