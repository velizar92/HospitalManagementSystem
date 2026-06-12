using HospitalManagementSystem.Application.DTOs.MedicalRecord;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public MedicalRecordService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateMedicalRecordAsync(CreateMedicalRecordDto createMedicalRecordDto)
    {
        var medicalRecord = new MedicalRecord
        {
            PatientId = createMedicalRecordDto.PatientId,
            DoctorId = createMedicalRecordDto.DoctorId,
            Diagnosis = createMedicalRecordDto.Diagnosis,
            TreatmentPlan = createMedicalRecordDto.TreatmentPlan,
            CreatedAt = createMedicalRecordDto.CreatedAt ?? DateTime.UtcNow,
            Symptoms = createMedicalRecordDto.Symptoms,
            Notes = createMedicalRecordDto.Notes,
            Allergies = createMedicalRecordDto.Allergies,
            ChronicConditions = createMedicalRecordDto.ChronicConditions,
            TestResults = createMedicalRecordDto.TestResults,
            AppointmentId = createMedicalRecordDto.AppointmentId
        };

        _dbContext.MedicalRecords.Add(medicalRecord);
        await _dbContext.SaveChangesAsync();

        return medicalRecord.Id;
    }

    public async Task<MedicalRecordDto> GetMedicalRecordAsync(int medicalRecordId)
    {
        if (medicalRecordId <= 0)
        {
            throw new ArgumentException("Medical record ID must be greater than zero.", nameof(medicalRecordId));
        }

        var medicalRecord = await _dbContext.MedicalRecords.FindAsync(medicalRecordId);

        if (medicalRecord == null)
        {
            throw new KeyNotFoundException($"Medical record with ID {medicalRecordId} not found.");
        }

        return new MedicalRecordDto
        {
            Id = medicalRecord.Id,
            PatientId = medicalRecord.PatientId,
            DoctorId = medicalRecord.DoctorId,
            Diagnosis = medicalRecord.Diagnosis,
            Symptoms = medicalRecord.Symptoms,
            Notes = medicalRecord.Notes,
            TreatmentPlan = medicalRecord.TreatmentPlan,
            Allergies = medicalRecord.Allergies,
            ChronicConditions = medicalRecord.ChronicConditions,
            TestResults = medicalRecord.TestResults,
            CreatedAt = medicalRecord.CreatedAt,
            AppointmentId = medicalRecord.AppointmentId
        };
    }

    public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAfterDateAsync(int doctorId, DateTime date)
    {
        return await _dbContext.MedicalRecords
            .Where(mr => mr.DoctorId == doctorId && mr.CreatedAt > date)
            .Select(mr => new MedicalRecordDto
            {
                Id = mr.Id,
                PatientId = mr.PatientId,
                DoctorId = mr.DoctorId,
                Diagnosis = mr.Diagnosis,
                Symptoms = mr.Symptoms,
                Notes = mr.Notes,
                TreatmentPlan = mr.TreatmentPlan,
                Allergies = mr.Allergies,
                ChronicConditions = mr.ChronicConditions,
                TestResults = mr.TestResults,
                CreatedAt = mr.CreatedAt,
                AppointmentId = mr.AppointmentId
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAsync()
    {
        return await _dbContext.MedicalRecords
            .Select(mr => new MedicalRecordDto
            {
                Id = mr.Id,
                PatientId = mr.PatientId,
                DoctorId = mr.DoctorId,
                Diagnosis = mr.Diagnosis,
                Symptoms = mr.Symptoms,
                Notes = mr.Notes,
                TreatmentPlan = mr.TreatmentPlan,
                Allergies = mr.Allergies,
                ChronicConditions = mr.ChronicConditions,
                TestResults = mr.TestResults,
                CreatedAt = mr.CreatedAt,
                AppointmentId = mr.AppointmentId
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsBeforeDateAsync(int doctorId, DateTime date)
    {
        return await _dbContext.MedicalRecords
            .Where(mr => mr.DoctorId == doctorId && mr.CreatedAt < date)
            .Select(mr => new MedicalRecordDto
            {
                Id = mr.Id,
                PatientId = mr.PatientId,
                DoctorId = mr.DoctorId,
                Diagnosis = mr.Diagnosis,
                Symptoms = mr.Symptoms,
                Notes = mr.Notes,
                TreatmentPlan = mr.TreatmentPlan,
                Allergies = mr.Allergies,
                ChronicConditions = mr.ChronicConditions,
                TestResults = mr.TestResults,
                CreatedAt = mr.CreatedAt,
                AppointmentId = mr.AppointmentId
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByDoctorIdAsync(int doctorId)
    {
        if (doctorId <= 0)
        {
            throw new ArgumentException("Doctor ID must be greater than zero.", nameof(doctorId));
        }

        return await _dbContext.MedicalRecords
            .Where(mr => mr.DoctorId == doctorId)
            .Select(mr => new MedicalRecordDto
            {
                Id = mr.Id,
                PatientId = mr.PatientId,
                DoctorId = mr.DoctorId,
                Diagnosis = mr.Diagnosis,
                Symptoms = mr.Symptoms,
                Notes = mr.Notes,
                TreatmentPlan = mr.TreatmentPlan,
                Allergies = mr.Allergies,
                ChronicConditions = mr.ChronicConditions,
                TestResults = mr.TestResults,
                CreatedAt = mr.CreatedAt,
                AppointmentId = mr.AppointmentId
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId)
    {
        if (patientId <= 0)
        {
            throw new ArgumentException("Patient ID must be greater than zero.", nameof(patientId));
        }

        return await _dbContext.MedicalRecords
            .Where(mr => mr.PatientId == patientId)
            .Select(mr => new MedicalRecordDto
            {
                Id = mr.Id,
                PatientId = mr.PatientId,
                DoctorId = mr.DoctorId,
                Diagnosis = mr.Diagnosis,
                Symptoms = mr.Symptoms,
                Notes = mr.Notes,
                TreatmentPlan = mr.TreatmentPlan,
                Allergies = mr.Allergies,
                ChronicConditions = mr.ChronicConditions,
                TestResults = mr.TestResults,
                CreatedAt = mr.CreatedAt,
                AppointmentId = mr.AppointmentId
            })
            .ToListAsync();
    }

    public async Task UpdateMedicalRecordAsync(UpdateMedicalRecordDto updateMedicalRecordDto)
    {
        if (updateMedicalRecordDto == null)
        {
            throw new ArgumentNullException(nameof(updateMedicalRecordDto), "UpdateMedicalRecordDto cannot be null.");
        }

        if (updateMedicalRecordDto.Id <= 0)
        {
            throw new ArgumentException("Medical record ID must be greater than zero.", nameof(updateMedicalRecordDto.Id));
        }

        var medicalRecord = await _dbContext.MedicalRecords.FindAsync(updateMedicalRecordDto.Id);

        if (medicalRecord == null)
        {
            throw new KeyNotFoundException($"Medical record with ID {updateMedicalRecordDto.Id} not found.");
        }

        medicalRecord.PatientId = updateMedicalRecordDto.PatientId ?? medicalRecord.PatientId;
        medicalRecord.DoctorId = updateMedicalRecordDto.DoctorId ?? medicalRecord.DoctorId;
        medicalRecord.Diagnosis = updateMedicalRecordDto.Diagnosis ?? medicalRecord.Diagnosis;
        medicalRecord.Symptoms = updateMedicalRecordDto.Symptoms ?? medicalRecord.Symptoms;
        medicalRecord.Notes = updateMedicalRecordDto.Notes ?? medicalRecord.Notes;
        medicalRecord.TreatmentPlan = updateMedicalRecordDto.TreatmentPlan ?? medicalRecord.TreatmentPlan;
        medicalRecord.Allergies = updateMedicalRecordDto.Allergies ?? medicalRecord.Allergies;
        medicalRecord.ChronicConditions = updateMedicalRecordDto.ChronicConditions ?? medicalRecord.ChronicConditions;
        medicalRecord.TestResults = updateMedicalRecordDto.TestResults ?? medicalRecord.TestResults;
        medicalRecord.AppointmentId = updateMedicalRecordDto.AppointmentId ?? medicalRecord.AppointmentId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteMedicalRecordAsync(int medicalRecordId)
    {
        if (medicalRecordId <= 0)
        {
            throw new ArgumentException("Medical record ID must be greater than zero.", nameof(medicalRecordId));
        }

        var medicalRecord = await _dbContext.MedicalRecords.FindAsync(medicalRecordId);

        if (medicalRecord == null)
        {
            throw new KeyNotFoundException($"Medical record with ID {medicalRecordId} not found.");
        }

        _dbContext.MedicalRecords.Remove(medicalRecord);
        await _dbContext.SaveChangesAsync();
    }
}
