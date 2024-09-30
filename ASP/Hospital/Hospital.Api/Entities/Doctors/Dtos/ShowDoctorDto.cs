namespace Hospital.Api.Entities.Doctors.Dtos;

public class ShowDoctorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
}