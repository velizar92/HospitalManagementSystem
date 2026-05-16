using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Doctor;

public class DoctorForUpdateDto
{
    [Required]
    public int Id { get; set; }
    public int? SupervisorId { get; set; }
    public int? DepartmentId { get; set; }
    public DoctorProfileDto? Profile { get; set; }
}
