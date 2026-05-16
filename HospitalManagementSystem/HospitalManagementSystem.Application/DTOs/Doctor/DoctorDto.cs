namespace HospitalManagementSystem.Application.DTOs.Doctor;

public class DoctorDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int? SupervisorId { get; set; }
    public int DepartmentId { get; set; }
    public DoctorProfileDto Profile { get; set; } = new DoctorProfileDto();
    public string? SupervisorFullName { get; set; }
    public string? DepartmentName { get; set; }
    public string FullName => $"{Profile.FirstName} {Profile.LastName}".Trim();
}
