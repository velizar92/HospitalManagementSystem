using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Patient;

public class CreatePatientDto
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public PatientProfileDto Profile { get; set; } = new PatientProfileDto();

    public bool IsActive { get; set; } = true;
}
