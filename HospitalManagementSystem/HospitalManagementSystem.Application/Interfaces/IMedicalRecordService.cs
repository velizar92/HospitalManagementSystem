using HospitalManagementSystem.Application.DTOs.MedicalRecord;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IMedicalRecordService
{
    Task<MedicalRecordDto> GetMedicalRecordAsync(int medicalRecordId);
    Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAsync();
    Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByDoctorIdAsync(int doctorId);
    Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId);
    Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsBeforeDateAsync(int doctorId, DateTime date);
    Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAfterDateAsync(int doctorId, DateTime date);
    Task<int> CreateMedicalRecordAsync(CreateMedicalRecordDto createMedicalRecordDto);
    Task DeleteMedicalRecordAsync(int medicalRecordId);
    Task UpdateMedicalRecordAsync(UpdateMedicalRecordDto updateMedicalRecordDto);
}
