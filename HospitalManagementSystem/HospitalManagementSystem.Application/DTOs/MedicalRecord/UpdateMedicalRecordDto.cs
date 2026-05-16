using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.MedicalRecord;

public class UpdateMedicalRecordDto 
{
    [Required]
    public int Id { get; set; }
    public int? PatientId { get; set; }
    public int? DoctorId { get; set; }
    public string? Diagnosis { get; set; }
    public string? Symptoms { get; set; }
    public string? Notes { get; set; }
    public string? TreatmentPlan { get; set; }
    public string? Allergies { get; set; }
    public string? ChronicConditions { get; set; }
    public string? TestResults { get; set; }
    public int? AppointmentId { get; set; }
    public DateTime? CreatedAt { get; set; }
}
