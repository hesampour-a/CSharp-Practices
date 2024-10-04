using Hospital.Api.Entities.Patients;
using Hospital.Api.Entities.Patients.Dtos;

namespace Hospital.Api.EfPersistence.Patients;

public interface IPatientRepository
{
    Task<IEnumerable<ShowPatientDto>> GetAllAsync(int doctorId);
    Task<Patient?> FindByIdAsync(int doctorId, int patientId);
}