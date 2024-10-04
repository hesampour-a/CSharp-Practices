using Hospital.Api.Entities.Patients;

namespace Hospital.Api.Entities.Doctors;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public List<Patient> Patients { get; set; } = [];
}