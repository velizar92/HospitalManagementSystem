using HospitalManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Appointment;

public class CreateAppointmentDto
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int DoctorId { get; set; }
    [Required]
    public int PatientId { get; set; }
    public AppointmentStatus? Status { get; set; }
}
