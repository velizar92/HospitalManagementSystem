namespace HospitalManagementSystem.Domain.Models;

public class DoctorProfile
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Specialty { get; set; }
    public string Qualification { get; set; }
    public string LicenseNumber { get; set; }
    public int YearsOfExperience { get; set; }
    public decimal ConsultationFee { get; set; }
}
