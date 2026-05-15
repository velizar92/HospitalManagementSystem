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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePatientProfile(modelBuilder);
        ConfigureDoctorProfile(modelBuilder);
        ConfigureAppointment(modelBuilder);
        ConfigureDepartment(modelBuilder);
        ConfigureMedicalRecord(modelBuilder);
        ConfigureInvoice(modelBuilder);
        ConfigureInvoiceItem(modelBuilder);
        ConfigurePrescription(modelBuilder);
        ConfigurePrescriptionItem(modelBuilder);
    }

    private void ConfigurePatientProfile(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.FirstName)
                .IsRequired();

        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.FirstName)
                .HasMaxLength(100);

        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.LastName)
                .IsRequired();

        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.LastName)
                .HasMaxLength(100);

        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.Gender)
                .IsRequired();

        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.PhoneNumber)
                .IsRequired();

        modelBuilder.Entity<PatientProfile>()
                .Property(e => e.BloodType)
                .IsRequired();
    }

    private void ConfigureDoctorProfile(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.FirstName)
               .IsRequired();

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.FirstName)
               .HasMaxLength(100);

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.LastName)
               .IsRequired();

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.LastName)
               .HasMaxLength(100);

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.PhoneNumber)
               .IsRequired();

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.LicenseNumber)
               .IsRequired();

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.Specialty)
               .IsRequired();

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.Qualification)
               .IsRequired();

        modelBuilder.Entity<DoctorProfile>()
               .Property(e => e.ConsultationFee)
               .IsRequired();
    }

    private void ConfigureAppointment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
               .Property(e => e.Date)
               .IsRequired();

        modelBuilder.Entity<Appointment>()
               .Property(e => e.Status)
               .IsRequired();

        modelBuilder.Entity<Appointment>()
               .Property(e => e.DoctorId)
               .IsRequired();

        modelBuilder.Entity<Appointment>()
               .Property(e => e.PatientId)
               .IsRequired();
    }

    private void ConfigureDepartment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
               .Property(e => e.Name)
               .IsRequired();
    }

    private void ConfigureMedicalRecord(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.DoctorId)
               .IsRequired();

        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.PatientId)
               .IsRequired();

        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.Diagnosis)
               .IsRequired();

        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.Symptoms)
               .IsRequired();

        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.TreatmentPlan)
               .IsRequired();

        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.TestResults)
               .IsRequired();

        modelBuilder.Entity<MedicalRecord>()
               .Property(e => e.AppointmentId)
               .IsRequired();
    }

    private void ConfigureInvoice(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
               .Property(e => e.TotalAmount)
               .IsRequired();

        modelBuilder.Entity<Invoice>()
               .Property(e => e.IsPaid)
               .IsRequired();

        modelBuilder.Entity<Invoice>()
              .Property(e => e.PatientId)
              .IsRequired();

        modelBuilder.Entity<Invoice>()
              .Property(e => e.AppointmentId)
              .IsRequired();
    }

    private void ConfigureInvoiceItem(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceItem>()
              .Property(e => e.InvoiceId)
              .IsRequired();

        modelBuilder.Entity<InvoiceItem>()
              .Property(e => e.Amount)
              .IsRequired();

        modelBuilder.Entity<InvoiceItem>()
             .Property(e => e.Description)
             .IsRequired();
    }

    private void ConfigurePrescription(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prescription>()
             .Property(e => e.PatientId)
             .IsRequired();

        modelBuilder.Entity<Prescription>()
             .Property(e => e.DoctorId)
             .IsRequired();

        modelBuilder.Entity<Prescription>()
             .Property(e => e.MedicalRecordId)
             .IsRequired();
    }

    private void ConfigurePrescriptionItem(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrescriptionItem>()
            .Property(e => e.PrescriptionId)
            .IsRequired();

        modelBuilder.Entity<PrescriptionItem>()
            .Property(e => e.MedicationName)
            .IsRequired();

        modelBuilder.Entity<PrescriptionItem>()
            .Property(e => e.Dosage)
            .IsRequired();

        modelBuilder.Entity<PrescriptionItem>()
            .Property(e => e.Frequency)
            .IsRequired();

        modelBuilder.Entity<PrescriptionItem>()
           .Property(e => e.DurationDays)
           .IsRequired();

        modelBuilder.Entity<PrescriptionItem>()
           .Property(e => e.Instructions)
           .IsRequired();
    }
}
