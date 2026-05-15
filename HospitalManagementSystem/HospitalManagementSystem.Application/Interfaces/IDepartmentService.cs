using HospitalManagementSystem.Application.DTOs.Department;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentDto?> GetDepartmentAsync(int departmentId);
    Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
    Task<int> AddDepartmentAsync(DepartmentCreateDto departmentCreateDto);
    Task DeleteDepartmentAsync(int departmentId);
    Task UpdateDepartmentAsync(DepartmentUpdateDto departmentUpdateDto);
}
