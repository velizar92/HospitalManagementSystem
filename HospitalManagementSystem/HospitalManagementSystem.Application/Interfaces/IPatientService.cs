using HospitalManagementSystem.Application.DTOs.Patient;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
    Task<PatientDto> GetPatientAsync(int id);
    Task<IEnumerable<PatientDto>> GetActivePatientsAsync();
    Task<PatientProfileDto?> GetPatientProfileAsync(int id);
    Task CreatePatientAsync(CreatePatientDto createPatientDto);
    Task UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto);
    Task UpdatePatientProfileAsync(int id, PatientProfileDto profileDto);
    Task DeletePatientAsync(int id);    
}

        