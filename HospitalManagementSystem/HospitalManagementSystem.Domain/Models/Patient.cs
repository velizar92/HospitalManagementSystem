namespace HospitalManagementSystem.Domain.Models;

public class Patient
{
    public int Id { get; set; }   
    public PatientProfile Profile { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = [];
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = [];
    public ICollection<Admission> Admissions { get; set; } = [];
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

