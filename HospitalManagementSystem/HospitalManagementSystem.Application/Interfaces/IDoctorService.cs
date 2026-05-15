using HospitalManagementSystem.Domain.Models;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IDoctorService
{
    Task<Doctor?> GetDoctorAsync(int doctorId);
    Task<Doctor?> GetDoctorByUserIdAsync(string userId);
    Task<int> GetDoctorsCountAsync();
    Task<IEnumerable<Doctor>> GetDoctorsAsync();


    Task<int> AddDoctorAsync(Doctor doctor);
    Task UpdateDoctorAsync(Doctor doctor);
    Task DeleteDoctorAsync(Doctor doctor);


    Task<IEnumerable<Doctor>> GetDoctorsByDepartmentAsync(int departmentId);
    Task<int> GetDoctorsCountInDepartmentAsync(int departmentId);


    Task<Doctor?> GetSupervisorAsync(int doctorId);
    Task<IEnumerable<Doctor>> GetSubordinatesAsync(int doctorId);


    Task<IEnumerable<Doctor>> GetDoctorsWithScheduledAppointmentsAsync(int departmentId);
    Task<IEnumerable<Doctor>> GetDoctorsWithCanceledAppointmentsAsync(int departmentId);
    Task<IEnumerable<Doctor>> GetDoctorsWithCompletedAppointmentsAsync(int departmentId);
}
