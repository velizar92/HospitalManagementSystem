using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Prescription;

public class UpdatePrescriptionDto
{
    [Required]
    public int Id { get; set; }
    public DateTime? PrescribedAt { get; set; }
    public ICollection<CreatePrescriptionItemDto>? Items { get; set; }
    public int? DoctorId { get; set; }
    public int? PatientId { get; set; }
    public int? MedicalRecordId { get; set; }
}
