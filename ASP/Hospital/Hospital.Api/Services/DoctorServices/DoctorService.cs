using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Doctors.Dtos;

namespace Hospital.Api.Services;

public interface DoctorService
{
    Task<int> AddAsync(CreateDoctorDto createDoctorDto);
    Task<IEnumerable<ShowDoctorDto>> GetAllAsync();
    Task<ShowDoctorDto?> GetByIdAsync(int id);
    Task EditAsync(int id, EditDoctorDto editDoctorDto);
    void Delete(int id);
}