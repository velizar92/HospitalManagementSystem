using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Addmission;

public class CreateAddmissionDto
{
    [Required]
    public int PatientId { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    public DateTime AdmissionDate { get; set; }

    public string Reason { get; set; } = string.Empty;
}
        