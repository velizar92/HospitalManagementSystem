using HospitalManagementSystem.Domain.Models;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IDepartmentService
{
    Department GetDepartment(int departmentId);
    IEnumerable<Department> GetDepartments();
    int AddDepartment(Department department);
    void DeleteDepartment(Department department);
    void UpdateDepartment(Department department);
}
