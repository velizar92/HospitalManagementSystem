using HospitalManagementSystem.Application.DTOs.Doctor;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] DoctorQuery query)
    {
        if (query.DepartmentId.HasValue)
        {
            var doctors = await _doctorService.GetDoctorsByDepartmentAsync(query.DepartmentId.Value);
            return Ok(doctors);
        }

        if (query.AppointmentStatus.HasValue)
        {
            var doctors = await _doctorService.GetDoctorsByAppointmentStatus(query.AppointmentStatus.Value);
            return Ok(doctors);
        }

        var allDoctors = await _doctorService.GetDoctorsAsync();
        return Ok(allDoctors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var doctor = await _doctorService.GetDoctorAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DoctorForCreateDto doctorForCreateDto)
    {
        var createdDoctorId = await _doctorService.CreateDoctorAsync(doctorForCreateDto);

        return CreatedAtAction(nameof(Get), new { id = createdDoctorId }, doctorForCreateDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] DoctorForUpdateDto doctorForUpdateDto)
    {
        if (await _doctorService.GetDoctorAsync(id) == null)
        {
            return NotFound();
        }

        await _doctorService.UpdateDoctorProfileAsync(id, doctorForUpdateDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _doctorService.GetDoctorAsync(id) == null)
        {
            return NotFound();
        }

        await _doctorService.DeleteDoctorAsync(id);

        return NoContent();
    }

    [HttpGet("{id}/supervisor")]
    public async Task<IActionResult> GetSupervisor(int id)
    {
        var supervisor = await _doctorService.GetSupervisorAsync(id);

        if (supervisor == null)
        {
            return NotFound();
        }

        return Ok(supervisor);
    }

    [HttpGet("{id}/subordinates")]
    public async Task<IActionResult> GetSubordinates(int id)
    {
        var subordinates = await _doctorService.GetSubordinatesAsync(id);

        return Ok(subordinates);
    }
}
