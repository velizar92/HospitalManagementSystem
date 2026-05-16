
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.MedicalRecord;

public class CreateMedicalRecordDto
{
    [Required]
    public int PatientId { get; set; }
    public int? DoctorId { get; set; }

    [Required]
    public string Diagnosis { get; set; } = string.Empty;

    public string Symptoms { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public string TreatmentPlan { get; set; } = string.Empty;

    public string Allergies { get; set; } = string.Empty;

    public string ChronicConditions { get; set; } = string.Empty;

    public string TestResults { get; set; } = string.Empty;

    public int? AppointmentId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
