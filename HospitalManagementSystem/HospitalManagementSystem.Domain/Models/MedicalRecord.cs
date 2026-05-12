namespace HospitalManagementSystem.Domain.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public string Diagnosis { get; set; }
        public string Symptoms { get; set; }
        public string Notes { get; set; }
        public string TreatmentPlan { get; set; }
        public string Allergies { get; set; }
        public string ChronicConditions { get; set; }
        public string TestResults { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

    }
}
