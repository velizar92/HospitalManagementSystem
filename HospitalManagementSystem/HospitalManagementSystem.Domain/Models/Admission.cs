namespace HospitalManagementSystem.Domain.Models;

public class Admission
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public string Reason { get; set; } 
    public bool IsActive { get; set; }
}
