using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.DTOs.Invoice;

public class UpdateInvoiceDto
{
    [Required]
    public int Id { get; set; }

    public bool? IsPaid { get; set; }

    public ICollection<CreateInvoiceItemDto>? Items { get; set; }
}
