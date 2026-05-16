using HospitalManagementSystem.Application.DTOs.Appointment;
using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IAppointmentService
{
    IEnumerable<AppointmentDto> GetAppointments(int doctorId, AppointmentStatus status);
    AppointmentDto GetAppointment(int appointmentId);
    void CreateAppointment(CreateAppointmentDto createAppointmentDto);
    void UpdateAppointment(UpdateAppointmentDto updateAppointmentDto);
    void DeleteAppointment(int appointmentId);
}
