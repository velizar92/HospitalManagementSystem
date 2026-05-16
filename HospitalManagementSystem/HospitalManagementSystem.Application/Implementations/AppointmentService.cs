using HospitalManagementSystem.Application.DTOs.Appointment;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Implementations;

public class AppointmentService : IAppointmentService
{
    public Task CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAppointmentAsync(int appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentDto> GetAppointmentAsync(int appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int doctorId, AppointmentStatus status)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAppointmentAsync(UpdateAppointmentDto updateAppointmentDto)
    {
        throw new NotImplementedException();
    }
}
