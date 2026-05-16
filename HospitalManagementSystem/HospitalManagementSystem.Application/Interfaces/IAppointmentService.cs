using HospitalManagementSystem.Application.DTOs.Appointment;
using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int doctorId, AppointmentStatus status);
    Task<AppointmentDto> GetAppointmentAsync(int appointmentId);
    Task CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto);
    Task UpdateAppointmentAsync(UpdateAppointmentDto updateAppointmentDto);
    Task DeleteAppointmentAsync(int appointmentId);
}
