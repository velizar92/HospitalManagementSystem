using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Doctor;

public class DoctorForCreateDto
{
    [Required]
    public string UserId { get; set; } = string.Empty;
    [Required]
    public int DepartmentId { get; set; }
    public int? SupervisorId { get; set; }
    [Required]
    public DoctorProfileDto Profile { get; set; } = new DoctorProfileDto();
}
