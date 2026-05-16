using HospitalManagementSystem.Application.DTOs.Addmission;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IAddmissionService
{
    Task<AddmissionDto?> GetAdmissionAsync(int admissionId);
    Task<IEnumerable<AddmissionDto>> GetAdmissionsAsync();
    Task<IEnumerable<AddmissionDto>> GetAdmissionsByPatientIdAsync(int patientId);
    Task<IEnumerable<AddmissionDto>> GetActiveAdmissionsAsync();

    Task<int> CreateAdmissionAsync(CreateAddmissionDto createAdmissionDto);
    Task UpdateAdmissionAsync(UpdateAddmissionDto updateAdmissionDto);
    Task DeleteAdmissionAsync(int admissionId);
}
