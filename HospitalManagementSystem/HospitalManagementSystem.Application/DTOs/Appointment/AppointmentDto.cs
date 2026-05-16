using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.DTOs.Appointment;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public AppointmentStatus Status { get; set; } 
}
