using HospitalManagementSystem.Application.DTOs.MedicalRecord;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class MedicalRecordService : IMedicalRecordService
{
    public Task<int> CreateMedicalRecordAsync(CreateMedicalRecordDto createMedicalRecordDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMedicalRecordAsync(int medicalRecordId)
    {
        throw new NotImplementedException();
    }

    public Task<MedicalRecordDto> GetMedicalRecordAsync(int medicalRecordId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAfterDateAsync(int doctorId, DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsBeforeDateAsync(int doctorId, DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByDoctorIdAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMedicalRecordAsync(UpdateMedicalRecordDto updateMedicalRecordDto)
    {
        throw new NotImplementedException();
    }
}
