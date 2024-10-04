using Hospital.Api.Entities.Patients;
using Hospital.Api.Entities.Patients.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.EfPersistence.Patients;

public class PatientRepository(EfDataContext dbContext) : IPatientRepository
{
    public async Task<IEnumerable<ShowPatientDto>> GetAllAsync(int doctorId)
    {
        return await dbContext.Patients.Where(_ => _.DoctorId == doctorId)
            .Select(_ => new ShowPatientDto
            {
                Name = _.Name,
                DoctorId = _.DoctorId,
            }).ToListAsync();
    }

    public Task<Patient?> FindByIdAsync(int doctorId, int patientId)
    {
       return dbContext.Patients
            .Where(_ => _.DoctorId == doctorId || _.Id == patientId)
            .FirstOrDefaultAsync();
    }
}