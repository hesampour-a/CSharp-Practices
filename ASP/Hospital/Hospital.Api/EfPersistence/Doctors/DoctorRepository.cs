using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Doctors.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.EfPersistence.Doctors;

public class DoctorRepository(EfDataContext dbContext) : IDoctorRepository
{
    public async Task<IEnumerable<ShowDoctorDto>> GetAll()
    {
        return await dbContext.Doctors.Select(_ => new ShowDoctorDto
        {
            Id = _.Id,
            Name = _.Name,
            Specialty = _.Specialty,
        }).ToListAsync();
    }

    public async Task Create(Doctor doctor)
    {
        await dbContext.Doctors.AddAsync(doctor);
        
    }
}