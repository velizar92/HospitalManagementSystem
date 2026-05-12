namespace HospitalManagementSystem.Domain.Models;

public class Prescription
{
    public int Id { get; set; }
    public int MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime PrescribedAt { get; set; } = DateTime.UtcNow;
    public ICollection<PrescriptionItem> Items { get; set; } = [];
}
