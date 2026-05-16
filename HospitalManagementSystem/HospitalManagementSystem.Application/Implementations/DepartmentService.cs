using HospitalManagementSystem.Application.DTOs.Department;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class DepartmentService : IDepartmentService
{
    public Task<int> AddDepartmentAsync(DepartmentCreateDto departmentCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDepartmentAsync(int departmentId)
    {
        throw new NotImplementedException();
    }

    public Task<DepartmentDto?> GetDepartmentAsync(int departmentId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateDepartmentAsync(DepartmentUpdateDto departmentUpdateDto)
    {
        throw new NotImplementedException();
    }
}
