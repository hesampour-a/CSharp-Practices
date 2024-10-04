using Hospital.Api.EfPersistence;
using Hospital.Api.EfPersistence.Doctors;
using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Doctors.Dtos;
using Hospital.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController(
    DoctorService doctorService
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await doctorService.GetAllAsync();

        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var doctor = await doctorService.GetByIdAsync(id);

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorDto doctor)
    {
        var newDoctorId = await doctorService.AddAsync(doctor);
        return CreatedAtAction(nameof(Get), new { id = newDoctorId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromRoute] int id,
        EditDoctorDto editDoctorDto)
    {
        await doctorService.EditAsync(id, editDoctorDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        doctorService.Delete(id);

        return NoContent();
    }
}