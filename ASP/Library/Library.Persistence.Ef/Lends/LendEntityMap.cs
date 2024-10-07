using Library.Entities.Lends;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Ef.Lends;

public class LendEntityMap : IEntityTypeConfiguration<Lend>
{
    public void Configure(EntityTypeBuilder<Lend> builder)
    {
        builder.ToTable("Lends");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(_ => _.LendDate).IsRequired();
        builder.Property(_ => _.ReturnDate).IsRequired();

        builder.HasOne(_ => _.Book).WithMany(_ => _.Lends)
            .HasForeignKey(_ => _.BookId);

        builder.HasOne(_ => _.User).WithMany(_ => _.Lends)
            .HasForeignKey(_ => _.UserId);

        builder.Property(_ => _.IsReturned).IsRequired();
    }
}