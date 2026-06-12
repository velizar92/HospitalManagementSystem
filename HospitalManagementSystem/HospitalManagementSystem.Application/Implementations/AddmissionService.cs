using HospitalManagementSystem.Application.DTOs.Addmission;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class AddmissionService : IAddmissionService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public AddmissionService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAdmissionAsync(CreateAddmissionDto createAdmissionDto)
    {
        var admission = new Admission
        {
            PatientId = createAdmissionDto.PatientId,
            RoomId = createAdmissionDto.RoomId,
            AdmissionDate = createAdmissionDto.AdmissionDate,
            DischargeDate = createAdmissionDto.DischargeDate,
            Reason = createAdmissionDto.Reason,
            IsActive = true
        };

        _dbContext.Admissions.Add(admission);
        await _dbContext.SaveChangesAsync();
        return admission.Id;

    }

    public async Task<IEnumerable<AddmissionDto>> GetActiveAdmissionsAsync()
    {
        return await _dbContext.Admissions
             .Where(a => a.IsActive)
             .Select(a => new AddmissionDto
             {
                 Id = a.Id,
                 PatientId = a.PatientId,
                 RoomId = a.RoomId,
                 AdmissionDate = a.AdmissionDate,
                 DischargeDate = a.DischargeDate,
                 Reason = a.Reason,
                 PatientFullName = a.Patient.Profile.FirstName + " " + a.Patient.Profile.LastName,
                 RoomNumber = a.Room.RoomNumber,
                 IsActive = a.IsActive
             })
             .ToListAsync();
    }

    public async Task<AddmissionDto?> GetAdmissionAsync(int admissionId)
    {
        return await _dbContext.Admissions
            .Where(a => a.Id == admissionId)
            .Select(a => new AddmissionDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                RoomId = a.RoomId,
                AdmissionDate = a.AdmissionDate,
                DischargeDate = a.DischargeDate,
                Reason = a.Reason,
                PatientFullName = a.Patient.Profile.FirstName + " " + a.Patient.Profile.LastName,
                RoomNumber = a.Room.RoomNumber,
                IsActive = a.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<AddmissionDto>> GetAdmissionsAsync()
    {
        return await _dbContext.Admissions
            .Select(a => new AddmissionDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                RoomId = a.RoomId,
                AdmissionDate = a.AdmissionDate,
                DischargeDate = a.DischargeDate,
                Reason = a.Reason,
                PatientFullName = a.Patient.Profile.FirstName + " " + a.Patient.Profile.LastName,
                RoomNumber = a.Room.RoomNumber,
                IsActive = a.IsActive
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<AddmissionDto>> GetAdmissionsByPatientIdAsync(int patientId)
    {
        return await _dbContext.Admissions
            .Where(a => a.PatientId == patientId)
            .Select(a => new AddmissionDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                RoomId = a.RoomId,
                AdmissionDate = a.AdmissionDate,
                DischargeDate = a.DischargeDate,
                Reason = a.Reason,
                PatientFullName = a.Patient.Profile.FirstName + " " + a.Patient.Profile.LastName,
                RoomNumber = a.Room.RoomNumber,
                IsActive = a.IsActive
            })
            .ToListAsync();
    }

    public async Task UpdateAdmissionAsync(UpdateAddmissionDto updateAdmissionDto)
    {
        var admission = await _dbContext.Admissions.FindAsync(updateAdmissionDto.Id);

        if (admission == null)
        {
            throw new KeyNotFoundException("Admission not found");
        }

        admission.Id = updateAdmissionDto.Id;
        admission.IsActive = updateAdmissionDto.IsActive;
        admission.Reason = updateAdmissionDto.Reason ?? admission.Reason;
        admission.AdmissionDate = updateAdmissionDto.AdmissionDate ?? admission.AdmissionDate;
        admission.DischargeDate = updateAdmissionDto.DischargeDate ?? admission.DischargeDate;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAdmissionAsync(int admissionId)
    {
        var admission = await _dbContext.Admissions.FindAsync(admissionId);

        if (admission == null)
        {
            throw new KeyNotFoundException("Admission not found");
        }

        _dbContext.Admissions.Remove(admission);
        await _dbContext.SaveChangesAsync();
    }
}