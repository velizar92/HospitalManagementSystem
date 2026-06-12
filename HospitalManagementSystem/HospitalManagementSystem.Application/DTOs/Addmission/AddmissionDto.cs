namespace HospitalManagementSystem.Application.DTOs.Addmission;

public class AddmissionDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int RoomId { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? PatientFullName { get; set; }
    public string? RoomNumber { get; set; }
    public bool IsActive { get; set; }
}
