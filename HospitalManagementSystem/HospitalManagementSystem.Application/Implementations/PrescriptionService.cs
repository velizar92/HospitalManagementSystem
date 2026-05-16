using HospitalManagementSystem.Application.DTOs.Prescription;
using HospitalManagementSystem.Application.Interfaces;

namespace HospitalManagementSystem.Application.Implementations;

public class PrescriptionService : IPrescriptionService
{
    public Task<int> CreatePrescriptionAsync(CreatePrescriptionDto prescription)
    {
        throw new NotImplementedException();
    }

    public Task DeletePrescriptionAsync(int prescriptionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAfterDateAsync(int doctorId, DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PrescriptionDto>> GetPrescriptionsBeforeDateAsync(int doctorId, DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePrescriptionAsync(UpdatePrescriptionDto prescription)
    {
        throw new NotImplementedException();
    }
}
