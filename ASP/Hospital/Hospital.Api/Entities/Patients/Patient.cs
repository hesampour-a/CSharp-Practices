using Hospital.Api.Entities.Doctors;

namespace Hospital.Api.Entities.Patients;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}