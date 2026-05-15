namespace HospitalManagementSystem.Application.DTOs.Department;

public class DepartmentDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int DoctorCount { get; init; }
}
