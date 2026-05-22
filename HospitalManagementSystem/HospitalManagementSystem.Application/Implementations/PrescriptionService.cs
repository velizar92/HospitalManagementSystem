using HospitalManagementSystem.Application.DTOs.Prescription;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class PrescriptionService : IPrescriptionService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public PrescriptionService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddPrescriptionAsync(CreatePrescriptionDto prescription)
    {
        var newPrescription = new Prescription
        {
            MedicalRecordId = prescription.MedicalRecordId,
            DoctorId = prescription.DoctorId,
            PatientId = prescription.PatientId,
            PrescribedAt = prescription.PrescribedAt ?? DateTime.UtcNow,
            Items = prescription.Items.Select(i => new PrescriptionItem
            {
                MedicationName = i.MedicationName,
                Dosage = i.Dosage,
                Frequency = i.Frequency,
                DurationDays = i.DurationDays
            }).ToList()
        };

        _dbContext.Prescriptions.Add(newPrescription);
        await _dbContext.SaveChangesAsync();

        return newPrescription.Id;
    }

    public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync(int doctorId)
    {
        return await _dbContext.Prescriptions
            .Where(p => p.DoctorId == doctorId)
            .Select(p => new PrescriptionDto
            {
                Id = p.Id,
                MedicalRecordId = p.MedicalRecordId,
                DoctorId = p.DoctorId,
                PatientId = p.PatientId,
                PrescribedAt = p.PrescribedAt,
                Items = p.Items.Select(i => new PrescriptionItemDto
                {
                    MedicationName = i.MedicationName,
                    Dosage = i.Dosage,
                    Frequency = i.Frequency,
                    DurationDays = i.DurationDays
                }).ToList(),
                DoctorFullName = $"{p.Doctor.Profile.FirstName} {p.Doctor.Profile.LastName}",
                PatientFullName = $"{p.Patient.Profile.FirstName} {p.Patient.Profile.LastName}"
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAfterDateAsync(int doctorId, DateTime date)
    {
        return await _dbContext.Prescriptions
            .Where(p => p.DoctorId == doctorId && p.PrescribedAt > date)
            .Select(p => new PrescriptionDto
            {
                Id = p.Id,
                MedicalRecordId = p.MedicalRecordId,
                DoctorId = p.DoctorId,
                PatientId = p.PatientId,
                PrescribedAt = p.PrescribedAt,
                Items = p.Items.Select(i => new PrescriptionItemDto
                {
                    MedicationName = i.MedicationName,
                    Dosage = i.Dosage,
                    Frequency = i.Frequency,
                    DurationDays = i.DurationDays
                }).ToList(),
                DoctorFullName = $"{p.Doctor.Profile.FirstName} {p.Doctor.Profile.LastName}",
                PatientFullName = $"{p.Patient.Profile.FirstName} {p.Patient.Profile.LastName}"
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsBeforeDateAsync(int doctorId, DateTime date)
    {
        return await _dbContext.Prescriptions
            .Where(p => p.DoctorId == doctorId && p.PrescribedAt < date)
            .Select(p => new PrescriptionDto
            {
                Id = p.Id,
                MedicalRecordId = p.MedicalRecordId,
                DoctorId = p.DoctorId,
                PatientId = p.PatientId,
                PrescribedAt = p.PrescribedAt,
                Items = p.Items.Select(i => new PrescriptionItemDto
                {
                    MedicationName = i.MedicationName,
                    Dosage = i.Dosage,
                    Frequency = i.Frequency,
                    DurationDays = i.DurationDays
                }).ToList(),
                DoctorFullName = $"{p.Doctor.Profile.FirstName} {p.Doctor.Profile.LastName}",
                PatientFullName = $"{p.Patient.Profile.FirstName} {p.Patient.Profile.LastName}"
            })
            .ToListAsync();
    }

    public async Task UpdatePrescriptionAsync(UpdatePrescriptionDto prescription)
    {
        var prescriptionForUpdate = await _dbContext.Prescriptions.FindAsync(prescription.Id);

        if (prescriptionForUpdate == null)
        {
            throw new KeyNotFoundException($"Prescription with ID {prescription.Id} not found.");
        }

        prescriptionForUpdate.PrescribedAt = prescription.PrescribedAt ?? prescriptionForUpdate.PrescribedAt;
        prescriptionForUpdate.DoctorId = prescription.DoctorId ?? prescriptionForUpdate.DoctorId;
        prescriptionForUpdate.PatientId = prescription.PatientId ?? prescriptionForUpdate.PatientId;
        prescriptionForUpdate.MedicalRecordId = prescription.MedicalRecordId ?? prescriptionForUpdate.MedicalRecordId;
        prescriptionForUpdate.Items = prescription.Items.Select(i => new PrescriptionItem
        {
            MedicationName = i.MedicationName,
            Dosage = i.Dosage,
            Frequency = i.Frequency,
            DurationDays = i.DurationDays
        }).ToList();

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePrescriptionAsync(int prescriptionId)
    {
        var prescription = await _dbContext.Prescriptions.FindAsync(prescriptionId);

        if (prescription == null)
        {
            throw new KeyNotFoundException($"Prescription with ID {prescriptionId} not found.");
        }

        _dbContext.Prescriptions.Remove(prescription);
        await _dbContext.SaveChangesAsync();
    }
}
