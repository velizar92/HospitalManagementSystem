namespace HospitalManagementSystem.Application.DTOs.Invoice;

public class InvoiceDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsPaid { get; set; }
    public int? AppointmentId { get; set; }
    public ICollection<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
    public string? PatientFullName { get; set; }
}
