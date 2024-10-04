using Hospital.Api.EfPersistence;
using Hospital.Api.EfPersistence.Patients;
using Hospital.Api.Entities.Patients;
using Hospital.Api.Entities.Patients.Dtos;
using Hospital.Api.Exceptions;

namespace Hospital.Api.Services.PatientServices;

public class PatientAppService(
    IPatientRepository patientRepository,
    IUintOfWork uintOfWork) : PatientService
{
    public async Task<IEnumerable<ShowPatientDto>> GetAllAsync(int doctorId)
    {
        return await patientRepository.GetAllAsync(doctorId);
    }

    public async Task<ShowPatientDto> GetById(int doctorId, int patientId)
    {
        var patient = await patientRepository.FindByIdAsync(doctorId, patientId)
                      ?? throw new NotFoundException(nameof(Patient),
                          patientId);

        return new ShowPatientDto
        {
            DoctorId = doctorId,
            Name = patient.Name,
        };
    }
}