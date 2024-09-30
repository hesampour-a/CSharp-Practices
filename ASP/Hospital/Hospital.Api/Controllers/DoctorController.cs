using Hospital.Api.EfPersistence;
using Hospital.Api.EfPersistence.Doctors;
using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Doctors.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController(
    IDoctorRepository doctorRepository,
    IUintOfWork uintOfWork) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await doctorRepository.GetAll();
        
        return Ok(restaurants);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorDto doctor)
    {
        await doctorRepository.Create(new Doctor
            {
                Name = doctor.Name,
                Specialty = doctor.Specialty,
            }
        );
        await uintOfWork.Save();
        return Ok();
    }
}