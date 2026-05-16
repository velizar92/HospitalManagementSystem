namespace HospitalManagementSystem.Application.DTOs.Patient;

public class PatientDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public PatientProfileDto Profile { get; set; } = new PatientProfileDto();
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public string FullName => $"{Profile.FirstName} {Profile.LastName}".Trim();
}
