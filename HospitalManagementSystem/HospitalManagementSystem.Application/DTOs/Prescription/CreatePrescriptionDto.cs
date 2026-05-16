using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Prescription;

public class CreatePrescriptionDto
{
    [Required]
    public int MedicalRecordId { get; set; }
    [Required]
    public int DoctorId { get; set; }
    [Required]
    public int PatientId { get; set; }
    public DateTime? PrescribedAt { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "At least one prescription item is required.")]
    public ICollection<CreatePrescriptionItemDto> Items { get; set; } = new List<CreatePrescriptionItemDto>();
}
