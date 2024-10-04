using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Doctors.Dtos;

namespace Hospital.Api.EfPersistence.Doctors;

public interface IDoctorRepository
{
    public Task<IEnumerable<ShowDoctorDto>> GetAll();
    Task<int> Create(Doctor doctor);
    Task<Doctor?> GetById(int id);
    void Delete(Doctor doctor);
    
}