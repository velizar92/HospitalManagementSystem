using HospitalManagementSystem.Application.DTOs.Patient;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class PatientService : IPatientService
{
    public Task CreatePatientAsync(CreatePatientDto createPatientDto)
    {
        throw new NotImplementedException();
    }

    public Task DeletePatientAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatientDto>> GetActivePatientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PatientDto> GetPatientAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PatientProfileDto?> GetPatientProfileAsync(Guid patientId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePatientProfileAsync(Guid patientId, PatientProfileDto profileDto)
    {
        throw new NotImplementedException();
    }
}
