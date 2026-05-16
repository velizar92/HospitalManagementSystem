using HospitalManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Appointment;

public class UpdateAppointmentDto
{
    [Required]
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public AppointmentStatus? Status { get; set; }
    public int? DoctorId { get; set; }
    public int? PatientId { get; set; }
}
