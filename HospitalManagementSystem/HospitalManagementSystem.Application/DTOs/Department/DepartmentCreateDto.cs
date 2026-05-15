using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Department;

public class DepartmentCreateDto
{
    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }
}
