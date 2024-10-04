using Hospital.Api.Entities.Patients.Dtos;

namespace Hospital.Api.Services.PatientServices;

public interface PatientService
{
    Task<IEnumerable<ShowPatientDto>> GetAllAsync(int doctorId);
    Task<ShowPatientDto> GetById(int doctorId, int patientId);
}