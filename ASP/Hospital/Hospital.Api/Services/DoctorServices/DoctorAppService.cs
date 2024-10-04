using Hospital.Api.EfPersistence;
using Hospital.Api.EfPersistence.Doctors;
using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Doctors.Dtos;
using Hospital.Api.Exceptions;

namespace Hospital.Api.Services;

public class DoctorAppService(
    IUintOfWork uintOfWork,
    IDoctorRepository doctorRepository) : DoctorService
{
    public async Task<int> AddAsync(CreateDoctorDto createDoctorDto)
    {
        var newDoctor = new Doctor
        {
            Name = createDoctorDto.Name,
            Specialty = createDoctorDto.Specialty,
        };
        await doctorRepository.Create(newDoctor
        );
        await uintOfWork.SaveAsync();
        return newDoctor.Id;
    }

    public Task<IEnumerable<ShowDoctorDto>> GetAllAsync()
    {
        return doctorRepository.GetAll();
    }

    public async Task<ShowDoctorDto?> GetByIdAsync(int id)
    {
        var doctor = await doctorRepository.GetById(id)
                     ?? throw new NotFoundException(nameof(Doctor), id);


        return new ShowDoctorDto
        {
            Id = doctor.Id,
            Specialty = doctor.Specialty,
            Name = doctor.Name
        };
    }

    public async Task EditAsync(int id, EditDoctorDto editDoctorDto)
    {
        var doctor = await doctorRepository.GetById(id)
                     ?? throw new NotFoundException(nameof(Doctor), id);

        doctor.Name = editDoctorDto.Name;
        doctor.Specialty = editDoctorDto.Specialty;
        await uintOfWork.SaveAsync();
        return;
    }

    public async void Delete(int id)
    {
        var doctor = await doctorRepository.GetById(id)
                     ?? throw new NotFoundException(nameof(Doctor), id);
        doctorRepository.Delete(doctor);
        uintOfWork.Save();
    }
}