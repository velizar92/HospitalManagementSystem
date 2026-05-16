using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Invoice;

public class CreateInvoiceDto
{
    [Required]
    public int PatientId { get; set; }

    public int? AppointmentId { get; set; }

    public DateTime? CreatedAt { get; set; }

    [Required]
    [MinLength(1)]
    public ICollection<CreateInvoiceItemDto> Items { get; set; } = new List<CreateInvoiceItemDto>();
}
