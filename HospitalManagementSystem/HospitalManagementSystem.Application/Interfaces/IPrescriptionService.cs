using HospitalManagementSystem.Application.DTOs.Prescription;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IPrescriptionService
{
    Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync(int doctorId);
    Task<IEnumerable<PrescriptionDto>> GetPrescriptionsBeforeDateAsync(int doctorId, DateTime date);
    Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAfterDateAsync(int doctorId, DateTime date);
    Task<int> AddPrescriptionAsync(CreatePrescriptionDto prescription);
    Task UpdatePrescriptionAsync(UpdatePrescriptionDto prescription);
    Task DeletePrescriptionAsync(int prescriptionId);
}
