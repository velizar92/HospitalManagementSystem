using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Addmission;

public class UpdateAddmissionDto
{
    [Required]
    public int Id { get; set; }
    public int? PatientId { get; set; }
    public int? RoomId { get; set; }
    public DateTime? AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public string? Reason { get; set; }
}
