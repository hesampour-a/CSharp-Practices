using Hospital.Api.Entities.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.EfPersistence.Doctors;

public class DoctorEntityMap : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");
        
        builder.HasKey(x => x.Id);
        builder.Property(_=>_.Id).UseIdentityColumn();

        builder.Property(_ => _.Name).IsRequired();
        
        builder.Property(_=>_.Specialty).IsRequired();
    }
}