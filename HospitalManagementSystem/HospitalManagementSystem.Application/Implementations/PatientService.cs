using HospitalManagementSystem.Application.DTOs.Patient;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class PatientService : IPatientService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public PatientService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreatePatientAsync(CreatePatientDto createPatientDto)
    {
        var patient = new Patient
        {
            UserId = createPatientDto.UserId,
            IsActive = createPatientDto.IsActive,
            Profile = new PatientProfile
            {
                FirstName = createPatientDto.Profile.FirstName,
                LastName = createPatientDto.Profile.LastName,
                DateOfBirth = createPatientDto.Profile.DateOfBirth
            }
        };

        _dbContext.Add(patient);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PatientDto> GetPatientAsync(int id)
    {
        return await _dbContext.Patients
            .Include(p => p.Profile)
            .Where(p => p.Id == id)
            .Select(p => new PatientDto
            {
                Id = p.Id,
                UserId = p.UserId,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                Profile = new PatientProfileDto
                {
                    FirstName = p.Profile.FirstName,
                    LastName = p.Profile.LastName,
                    DateOfBirth = p.Profile.DateOfBirth
                }
            })
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Patient with ID {id} not found.");
    }

    public async Task<IEnumerable<PatientDto>> GetActivePatientsAsync()
    {
        return await _dbContext.Patients
            .Include(p => p.Profile)
            .Where(p => p.IsActive)
            .Select(p => new PatientDto
            {
                Id = p.Id,
                UserId = p.UserId,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                Profile = new PatientProfileDto
                {
                    FirstName = p.Profile.FirstName,
                    LastName = p.Profile.LastName,
                    DateOfBirth = p.Profile.DateOfBirth
                }
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
    {
        return await _dbContext.Patients
            .Include(p => p.Profile)
            .Select(p => new PatientDto
            {
                Id = p.Id,
                UserId = p.UserId,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                Profile = new PatientProfileDto
                {
                    FirstName = p.Profile.FirstName,
                    LastName = p.Profile.LastName,
                    DateOfBirth = p.Profile.DateOfBirth
                }
            })
            .ToListAsync();
    }

    public async Task<PatientProfileDto?> GetPatientProfileAsync(int id)
    {
        var patient = await _dbContext.Patients
            .Include(p => p.Profile)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (patient == null)
        {
            return null;
        }

        return new PatientProfileDto
        {
            FirstName = patient.Profile.FirstName,
            LastName = patient.Profile.LastName,
            DateOfBirth = patient.Profile.DateOfBirth
        };
    }

    public async Task UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto)
    {
        var patient = await _dbContext.Patients.FindAsync(id);

        if (patient == null)
        {
            throw new KeyNotFoundException($"Patient with ID {id} not found.");
        }

        patient.UserId = updatePatientDto.UserId ?? patient.UserId;
        patient.IsActive = updatePatientDto.IsActive;

        if (updatePatientDto.Profile != null)
        {
            patient.Profile.FirstName = updatePatientDto.Profile.FirstName;
            patient.Profile.LastName = updatePatientDto.Profile.LastName;
            patient.Profile.DateOfBirth = updatePatientDto.Profile.DateOfBirth;
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePatientProfileAsync(int id, PatientProfileDto profileDto)
    {
        var patientProfile = await _dbContext.PatientProfiles
            .FirstOrDefaultAsync(p => p.PatientId == id);

        if (patientProfile == null)
        {
            throw new KeyNotFoundException($"Patient profile with ID {id} not found.");
        }

        patientProfile.FirstName = profileDto.FirstName;
        patientProfile.LastName = profileDto.LastName;
        patientProfile.DateOfBirth = profileDto.DateOfBirth;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePatientAsync(int id)
    {
        var patient = await _dbContext.Patients.FindAsync(id);

        if (patient == null)
        {
            throw new KeyNotFoundException($"Patient with ID {id} not found.");
        }

        _dbContext.Patients.Remove(patient);
        await _dbContext.SaveChangesAsync();
    } 
}
