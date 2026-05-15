namespace HospitalManagementSystem.Domain.Models;

public class Doctor
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty; 
    public DoctorProfile Profile { get; set; }  
    public int? SupervisorId { get; set; }
    public Doctor? Supervisor { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public ICollection<Doctor> Subordinates { get; set; } = [];
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = [];
    public ICollection<Appointment> Appointments { get; set; } = [];
}
