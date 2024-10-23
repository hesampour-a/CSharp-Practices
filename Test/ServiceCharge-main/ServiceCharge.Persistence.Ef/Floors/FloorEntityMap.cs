using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceCharge.Entities;

namespace ServiceCharge.Persistence.Ef.Floors;

public class FloorEntityMap : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.ToTable("Floors");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.HasOne(_ => _.Block).WithMany(_ => _.Floors)
            .HasForeignKey(_ => _.BlockId);
    }
}