using HospitalManagementSystem.Domain.Models;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IDepartmentService
{
    Task<Department?> GetDepartmentAsync(int departmentId);
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task<int> AddDepartmentAsync(Department department);
    Task DeleteDepartmentAsync(Department department);
    Task UpdateDepartmentAsync(Department department);
}
