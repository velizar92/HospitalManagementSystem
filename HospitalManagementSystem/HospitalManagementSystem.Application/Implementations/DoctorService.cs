using HospitalManagementSystem.Application.DTOs.Doctor;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Queries;
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
        if (doctorForCreate is null)
        {
            throw new ArgumentNullException(nameof(doctorForCreate));
        }

        await ValidateDoctor(doctorForCreate);

        var doctor = MapToEntity(doctorForCreate);

        _dbContext.Doctors.Add(doctor);
        await _dbContext.SaveChangesAsync();

        return doctor.Id;
    }

    public async Task<DoctorDto?> GetDoctorAsync(int doctorId)
    {
        if (doctorId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }
            
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
        if (doctorId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

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

    public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync(DoctorQuery query)
    {
        var doctorsQuery = _dbContext.Doctors.AsQueryable();
  
        if (query.DepartmentId.HasValue)
        {
            doctorsQuery = doctorsQuery
                .Where(d => d.DepartmentId == query.DepartmentId.Value);
        }
     
        if (query.AppointmentStatus.HasValue)
        {
            doctorsQuery = doctorsQuery.Where(d =>
                _dbContext.Appointments.Any(a =>
                    a.DoctorId == d.Id &&
                    a.Status == query.AppointmentStatus.Value));
        }
     
        doctorsQuery = query.OrderBy?.ToLower() switch
        {
            "name" => query.Desc
                ? doctorsQuery.OrderByDescending(d => d.Profile.LastName)
                : doctorsQuery.OrderBy(d => d.Profile.LastName),

            "experience" => query.Desc
                ? doctorsQuery.OrderByDescending(d => d.Profile.YearsOfExperience)
                : doctorsQuery.OrderBy(d => d.Profile.YearsOfExperience),

            "fee" => query.Desc
                ? doctorsQuery.OrderByDescending(d => d.Profile.ConsultationFee)
                : doctorsQuery.OrderBy(d => d.Profile.ConsultationFee),

            _ => doctorsQuery.OrderBy(d => d.Id)
        };

        var pagedDoctors = doctorsQuery
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize);

        return await pagedDoctors
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
                SupervisorFullName = d.Supervisor != null
                    ? $"{d.Supervisor.Profile.FirstName} {d.Supervisor.Profile.LastName}"
                    : null,
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
        if (departmentId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

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
        if (departmentId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        return await _dbContext.Doctors.CountAsync(d => d.DepartmentId == departmentId);
    }

    public async Task<IEnumerable<DoctorDto>> GetSubordinatesAsync(int doctorId)
    {
        if (doctorId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

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
        if (doctorId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

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
        if (doctorId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        if (doctorForUpdate.Id != doctorId)
        {
            throw new ArgumentException("Mismatch between route doctorId and payload Id.");
        }

        var doctor = await _dbContext.Doctors
                .Include(d => d.Profile)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

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

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDoctorAsync(int doctorId)
    {
        if (doctorId <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        var doctor = await _dbContext.Doctors.FindAsync(doctorId);

        if (doctor == null)
        {
            throw new KeyNotFoundException("Doctor not found");
        }

        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();
    }

    private async Task ValidateDoctor(DoctorForCreateDto doctorForCreate)
    {
        bool licenseExists = await _dbContext.Doctors
               .AsNoTracking()
               .AnyAsync(d => d.Profile.LicenseNumber == doctorForCreate.Profile.LicenseNumber);

        if (licenseExists)
        {
            throw new InvalidOperationException("Doctor with this license already exists");
        }

        bool departmentExists = await _dbContext.Departments
                .AnyAsync(d => d.Id == doctorForCreate.DepartmentId);

        if (!departmentExists)
        {
            throw new InvalidOperationException("Invalid department");
        }
    }

    private Doctor MapToEntity(DoctorForCreateDto doctorForCreate)
    {
        return new Doctor
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
    }
}
