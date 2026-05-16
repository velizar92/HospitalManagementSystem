using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Patient;

public class UpdatePatientDto
{
    [Required]
    public int Id { get; set; }

    public string? UserId { get; set; }

    public PatientProfileDto? Profile { get; set; }

    public bool? IsActive { get; set; }
}
