using HospitalManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Data;

public class HospitalManagementSystemDbContext : DbContext
{
    public HospitalManagementSystemDbContext(DbContextOptions<HospitalManagementSystemDbContext> options)
        : base(options)
    {
    }
   
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientProfile> PatientProfiles { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorProfile> DoctorProfiles { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
}
