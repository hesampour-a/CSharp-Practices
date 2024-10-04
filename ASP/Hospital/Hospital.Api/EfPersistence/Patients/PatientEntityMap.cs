using Hospital.Api.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.EfPersistence.Patients;

public class PatientEntityMap : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();

        builder.HasOne(_ => _.Doctor).WithMany(_ => _.Patients)
            .HasForeignKey(_ => _.DoctorId);
    }
}