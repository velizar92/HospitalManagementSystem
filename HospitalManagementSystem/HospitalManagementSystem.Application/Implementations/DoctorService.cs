using HospitalManagementSystem.Application.DTOs.Doctor;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Enums;
using HospitalManagementSystem.Domain.Models;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Implementations;

public class DoctorService : IDoctorService
{
    private readonly HospitalManagementSystemDbContext _dbContext;

    public DoctorService(HospitalManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateDoctorAsync(DoctorForCreateDto doctorForCreate)
    {
        var doctor = new Doctor
        {
            UserId = doctorForCreate.UserId,
            DepartmentId = doctorForCreate.DepartmentId,
            SupervisorId = doctorForCreate.SupervisorId,
            Profile = new DoctorProfile
            {
                FirstName = doctorForCreate.Profile.FirstName,
                LastName = doctorForCreate.Profile.LastName,
                PhoneNumber = doctorForCreate.Profile.PhoneNumber,
                Specialty = doctorForCreate.Profile.Specialty,
                Qualification = doctorForCreate.Profile.Qualification,
                LicenseNumber = doctorForCreate.Profile.LicenseNumber,
                YearsOfExperience = doctorForCreate.Profile.YearsOfExperience,
                ConsultationFee = doctorForCreate.Profile.ConsultationFee,
            }
        };

        _dbContext.Doctors.Add(doctor);
        await _dbContext.SaveChangesAsync();

        return doctor.Id;
    }

    public async Task DeleteDoctorAsync(int doctorId)
    {
        var doctor = await _dbContext.Doctors.FindAsync(doctorId);

        if (doctor == null)
        {
            throw new KeyNotFoundException("Doctor not found");
        }

        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<DoctorDto?> GetDoctorAsync(int doctorId)
    {
        return await _dbContext.Doctors
            .Where(d => d.Id == doctorId)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                SupervisorId = d.SupervisorId,
                DepartmentId = d.DepartmentId,
                Profile = new DoctorProfileDto
                {
                    FirstName = d.Profile.FirstName,
                    LastName = d.Profile.LastName,
                    PhoneNumber = d.Profile.PhoneNumber,
                    Specialty = d.Profile.Specialty,
                    Qualification = d.Profile.Qualification,
                    LicenseNumber = d.Profile.LicenseNumber,
                    YearsOfExperience = d.Profile.YearsOfExperience,
                    ConsultationFee = d.Profile.ConsultationFee,
                },
                SupervisorFullName = d.Supervisor != null ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}" : null,
                DepartmentName = d.Department.Name,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<DoctorDto?> GetDoctorByUserIdAsync(string userId)
    {
        return await _dbContext.Doctors
            .Where(d => d.UserId == userId)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                SupervisorId = d.SupervisorId,
                DepartmentId = d.DepartmentId,
                Profile = new DoctorProfileDto
                {
                    FirstName = d.Profile.FirstName,
                    LastName = d.Profile.LastName,
                    PhoneNumber = d.Profile.PhoneNumber,
                    Specialty = d.Profile.Specialty,
                    Qualification = d.Profile.Qualification,
                    LicenseNumber = d.Profile.LicenseNumber,
                    YearsOfExperience = d.Profile.YearsOfExperience,
                    ConsultationFee = d.Profile.ConsultationFee,
                },
                SupervisorFullName = d.Supervisor != null ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}" : null,
                DepartmentName = d.Department.Name,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId)
    {
        return await _dbContext.Doctors
            .Where(d => d.Id == doctorId)
            .Select(d => new DoctorProfileDto
            {
                FirstName = d.Profile.FirstName,
                LastName = d.Profile.LastName,
                PhoneNumber = d.Profile.PhoneNumber,
                Specialty = d.Profile.Specialty,
                Qualification = d.Profile.Qualification,
                LicenseNumber = d.Profile.LicenseNumber,
                YearsOfExperience = d.Profile.YearsOfExperience,
                ConsultationFee = d.Profile.ConsultationFee,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
    {
       return await _dbContext.Doctors
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                SupervisorId = d.SupervisorId,
                DepartmentId = d.DepartmentId,
                Profile = new DoctorProfileDto
                {
                    FirstName = d.Profile.FirstName,
                    LastName = d.Profile.LastName,
                    PhoneNumber = d.Profile.PhoneNumber,
                    Specialty = d.Profile.Specialty,
                    Qualification = d.Profile.Qualification,
                    LicenseNumber = d.Profile.LicenseNumber,
                    YearsOfExperience = d.Profile.YearsOfExperience,
                    ConsultationFee = d.Profile.ConsultationFee,
                },
                SupervisorFullName = d.Supervisor != null ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}" : null,
                DepartmentName = d.Department.Name,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<DoctorDto>> GetDoctorsByAppointmentStatus(AppointmentStatus status)
    {
        return await _dbContext.Appointments
            .Where(a => a.Status == status)
            .Select(a => a.Doctor)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                SupervisorId = d.SupervisorId,
                DepartmentId = d.DepartmentId,
                Profile = new DoctorProfileDto
                {
                    FirstName = d.Profile.FirstName,
                    LastName = d.Profile.LastName,
                    PhoneNumber = d.Profile.PhoneNumber,
                    Specialty = d.Profile.Specialty,
                    Qualification = d.Profile.Qualification,
                    LicenseNumber = d.Profile.LicenseNumber,
                    YearsOfExperience = d.Profile.YearsOfExperience,
                    ConsultationFee = d.Profile.ConsultationFee,
                },
                SupervisorFullName = d.Supervisor != null ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}" : null,
                DepartmentName = d.Department.Name,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<DoctorDto>> GetDoctorsByDepartmentAsync(int departmentId)
    {
        return await _dbContext.Doctors
            .Where(d => d.DepartmentId == departmentId)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                SupervisorId = d.SupervisorId,
                DepartmentId = d.DepartmentId,
                Profile = new DoctorProfileDto
                {
                    FirstName = d.Profile.FirstName,
                    LastName = d.Profile.LastName,
                    PhoneNumber = d.Profile.PhoneNumber,
                    Specialty = d.Profile.Specialty,
                    Qualification = d.Profile.Qualification,
                    LicenseNumber = d.Profile.LicenseNumber,
                    YearsOfExperience = d.Profile.YearsOfExperience,
                    ConsultationFee = d.Profile.ConsultationFee,
                },
                SupervisorFullName = d.Supervisor != null ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}" : null,
                DepartmentName = d.Department.Name,
            })
            .ToListAsync();
    }

    public async Task<int> GetDoctorsCountAsync()
    {
        return await _dbContext.Doctors.CountAsync();
    }

    public async Task<int> GetDoctorsCountInDepartmentAsync(int departmentId)
    {
        return await _dbContext.Doctors.CountAsync(d => d.DepartmentId == departmentId);
    }

    public async Task<IEnumerable<DoctorDto>> GetSubordinatesAsync(int doctorId)
    {
       return await _dbContext.Doctors
            .Where(d => d.SupervisorId == doctorId)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId,
                SupervisorId = d.SupervisorId,
                DepartmentId = d.DepartmentId,
                Profile = new DoctorProfileDto
                {
                    FirstName = d.Profile.FirstName,
                    LastName = d.Profile.LastName,
                    PhoneNumber = d.Profile.PhoneNumber,
                    Specialty = d.Profile.Specialty,
                    Qualification = d.Profile.Qualification,
                    LicenseNumber = d.Profile.LicenseNumber,
                    YearsOfExperience = d.Profile.YearsOfExperience,
                    ConsultationFee = d.Profile.ConsultationFee,
                },
                SupervisorFullName = d.Supervisor != null ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}" : null,
                DepartmentName = d.Department.Name,
            })
            .ToListAsync();
    }

    public async Task<DoctorDto?> GetSupervisorAsync(int doctorId)
    {
        var doctor = await _dbContext.Doctors
            .Include(d => d.Supervisor)
            .FirstOrDefaultAsync(d => d.Id == doctorId);

        if (doctor?.Supervisor == null)
        {
            return null;
        }
            
        var supervisor = doctor.Supervisor;

        return new DoctorDto
        {
            Id = supervisor.Id,
            UserId = supervisor.UserId,
            SupervisorId = supervisor.SupervisorId,
            DepartmentId = supervisor.DepartmentId,
            Profile = new DoctorProfileDto
            {
                FirstName = supervisor.Profile.FirstName,
                LastName = supervisor.Profile.LastName,
                PhoneNumber = supervisor.Profile.PhoneNumber,
                Specialty = supervisor.Profile.Specialty,
                Qualification = supervisor.Profile.Qualification,
                LicenseNumber = supervisor.Profile.LicenseNumber,
                YearsOfExperience = supervisor.Profile.YearsOfExperience,
                ConsultationFee = supervisor.Profile.ConsultationFee,
            },
            SupervisorFullName = supervisor.Supervisor != null ? $"{supervisor.Supervisor.Profile.FirstName} {supervisor.Supervisor.Profile.LastName}" : null,
            DepartmentName = supervisor.Department.Name,
        };
    }

    public async Task UpdateDoctorProfileAsync(int doctorId, DoctorForUpdateDto doctorForUpdate)
    {
        var doctor = await _dbContext.Doctors.FindAsync(doctorForUpdate.Id);

        if (doctor == null)
        {
            throw new KeyNotFoundException("Doctor not found");
        }

        doctor.Id = doctorForUpdate.Id;
        doctor.SupervisorId = doctorForUpdate.SupervisorId;
        doctor.Profile.FirstName = doctorForUpdate.Profile.FirstName;
        doctor.Profile.LastName = doctorForUpdate.Profile.LastName;
        doctor.Profile.PhoneNumber = doctorForUpdate.Profile.PhoneNumber;
        doctor.Profile.Specialty = doctorForUpdate.Profile.Specialty;
        doctor.Profile.Qualification = doctorForUpdate.Profile.Qualification;
        doctor.Profile.LicenseNumber = doctorForUpdate.Profile.LicenseNumber;
        doctor.Profile.YearsOfExperience = doctorForUpdate.Profile.YearsOfExperience;
        doctor.Profile.ConsultationFee = doctorForUpdate.Profile.ConsultationFee;
    }
}
