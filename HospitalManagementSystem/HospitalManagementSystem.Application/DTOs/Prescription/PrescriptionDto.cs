namespace HospitalManagementSystem.Application.DTOs.Prescription;

public class PrescriptionDto
{
    public int Id { get; set; }
    public int MedicalRecordId { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime PrescribedAt { get; set; }
    public ICollection<PrescriptionItemDto> Items { get; set; } = new List<PrescriptionItemDto>();
    public string? DoctorFullName { get; set; }
    public string? PatientFullName { get; set; }
}
