using HospitalManagementSystem.Application.DTOs.Doctor;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Implementations;

public class DoctorService : IDoctorService
{
    public Task<int> AddDoctorAsync(DoctorForCreateDto doctorForCreate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDoctorAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto?> GetDoctorAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto?> GetDoctorByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DoctorDto>> GetDoctorsByAppointmentStatus(AppointmentStatus status)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DoctorDto>> GetDoctorsByDepartmentAsync(int departmentId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetDoctorsCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetDoctorsCountInDepartmentAsync(int departmentId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DoctorDto>> GetSubordinatesAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto?> GetSupervisorAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDoctorAsync(DoctorForUpdateDto doctorForUpdate)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDoctorProfileAsync(int doctorId, DoctorProfileDto profileDto)
    {
        throw new NotImplementedException();
    }
}
