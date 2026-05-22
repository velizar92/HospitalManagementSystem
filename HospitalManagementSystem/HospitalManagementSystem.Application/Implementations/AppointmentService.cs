using HospitalManagementSystem.Application.DTOs.Appointment;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Enums;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class AppointmentService : IAppointmentService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public AppointmentService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
    {
        var appointment = new Appointment
        {
            DoctorId = createAppointmentDto.DoctorId,
            PatientId = createAppointmentDto.PatientId,
            Date = createAppointmentDto.Date,
            Status = AppointmentStatus.Scheduled
        };

        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<AppointmentDto?> GetAppointmentAsync(int appointmentId)
    {
        return await _dbContext.Appointments
            .Where(appointment => appointment.Id == appointmentId)
            .Select(appointment => new AppointmentDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                Date = appointment.Date,
                Status = appointment.Status
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int doctorId, AppointmentStatus status)
    {
        return await _dbContext.Appointments
            .Where(appointment => appointment.DoctorId == doctorId && appointment.Status == status)
            .Select(appointment => new AppointmentDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                Date = appointment.Date,
                Status = appointment.Status
            })
            .ToListAsync();
    }

    public async Task UpdateAppointmentAsync(UpdateAppointmentDto updateAppointmentDto)
    {
        var appointment = await _dbContext.Appointments.FindAsync(updateAppointmentDto.Id);

        if (appointment == null)
        {
            throw new KeyNotFoundException("Appointment not found");
        }

        appointment.Date = updateAppointmentDto.Date ?? appointment.Date;
        appointment.Status = updateAppointmentDto.Status ?? appointment.Status;
        appointment.DoctorId = updateAppointmentDto.DoctorId ?? appointment.DoctorId;
        appointment.PatientId = updateAppointmentDto.PatientId ?? appointment.PatientId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAppointmentAsync(int appointmentId)
    {
        var appointment = await _dbContext.Appointments.FindAsync(appointmentId);

        if (appointment == null)
        {
            throw new InvalidOperationException("Appointment with the specified ID not found.");
        }

        _dbContext.Appointments.Remove(appointment);
        await _dbContext.SaveChangesAsync();
    }
}
