using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.DTOs.Appointment;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public AppointmentStatus Status { get; set; }
}
