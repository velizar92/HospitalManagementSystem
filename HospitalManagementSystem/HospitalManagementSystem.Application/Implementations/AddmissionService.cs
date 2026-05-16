using HospitalManagementSystem.Application.DTOs.Addmission;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class AddmissionService : IAddmissionService
{
    public Task<int> CreateAdmissionAsync(CreateAddmissionDto createAdmissionDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAdmissionAsync(int admissionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AddmissionDto>> GetActiveAdmissionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AddmissionDto?> GetAdmissionAsync(int admissionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AddmissionDto>> GetAdmissionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AddmissionDto>> GetAdmissionsByPatientIdAsync(int patientId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAdmissionAsync(UpdateAddmissionDto updateAdmissionDto)
    {
        throw new NotImplementedException();
    }
}
