using HospitalManagementSystem.Application.DTOs.Doctor;
using HospitalManagementSystem.Domain.Enums;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IDoctorService
{
    Task<DoctorDto?> GetDoctorAsync(int doctorId);
    Task<DoctorDto?> GetDoctorByUserIdAsync(string userId);
    Task<int> GetDoctorsCountAsync();
    Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
    Task<IEnumerable<DoctorDto>> GetDoctorsByDepartmentAsync(int departmentId);
    Task<int> GetDoctorsCountInDepartmentAsync(int departmentId);
    Task<int> CreateDoctorAsync(DoctorForCreateDto doctorForCreate);
    Task DeleteDoctorAsync(int doctorId);
    Task<DoctorDto?> GetSupervisorAsync(int doctorId);
    Task<IEnumerable<DoctorDto>> GetSubordinatesAsync(int doctorId);
    Task<IEnumerable<DoctorDto>> GetDoctorsByAppointmentStatus(AppointmentStatus status);
    Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId);
    Task UpdateDoctorProfileAsync(int doctorId, DoctorForUpdateDto profileDto);
}
