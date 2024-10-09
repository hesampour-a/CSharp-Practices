using Hospital.Api.EfPersistence;
using Hospital.Api.Entities.Patients.Dtos;
using Hospital.Api.Services.PatientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
    [Route("api/Doctors/{doctorId}/[controller]")]
    [ApiController]
    public class PatientController(PatientService patientService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int doctorId)
        {
            var patients = await patientService.GetAllAsync(doctorId);
            return Ok(patients);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> Get([FromRoute] int doctorId,
            [FromRoute] int patientId)
        {
            var patient = await patientService.GetById(doctorId, patientId);
            return Ok(patient);
        }
    }
}