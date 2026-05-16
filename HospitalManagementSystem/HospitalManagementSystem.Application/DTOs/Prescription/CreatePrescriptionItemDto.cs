using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Prescription;

public class CreatePrescriptionItemDto
{
    [Required]
    public string MedicationName { get; set; } = string.Empty;
    [Required]
    public string Dosage { get; set; } = string.Empty;
    [Required]
    public string Frequency { get; set; } = string.Empty;
    [Range(1, int.MaxValue)]
    public int DurationDays { get; set; }
    public string Instructions { get; set; } = string.Empty;
}
