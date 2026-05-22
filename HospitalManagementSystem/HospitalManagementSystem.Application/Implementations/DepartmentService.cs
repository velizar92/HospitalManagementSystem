using HospitalManagementSystem.Application.DTOs.Department;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public DepartmentService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddDepartmentAsync(DepartmentCreateDto departmentCreateDto)
    {
        var department = new Department
        {
            Name = departmentCreateDto.Name,
            Description = departmentCreateDto.Description
        };

        _dbContext.Departments.Add(department);
        await _dbContext.SaveChangesAsync();

        return department.Id;
    }

    public async Task<DepartmentDto?> GetDepartmentAsync(int departmentId)
    {
        return await _dbContext.Departments
            .Where(d => d.Id == departmentId)
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                DoctorCount = d.Doctors.Count
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
    {
        return await _dbContext.Departments
             .Select(d => new DepartmentDto
             {
                 Id = d.Id,
                 Name = d.Name,
                 Description = d.Description,
                 DoctorCount = d.Doctors.Count
             })
             .ToListAsync();
    }

    public async Task UpdateDepartmentAsync(DepartmentUpdateDto departmentUpdateDto)
    {
        var department = await _dbContext.Departments.FindAsync(departmentUpdateDto.Id);

        if(department == null)
        {
            throw new KeyNotFoundException("Department not found");
        }

        department.Name = departmentUpdateDto.Name;
        department.Description = departmentUpdateDto.Description;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDepartmentAsync(int departmentId)
    {
        var department = await _dbContext.Departments.FindAsync(departmentId);

        _dbContext.Departments.Remove(department!);
        await _dbContext.SaveChangesAsync();
    }
}
