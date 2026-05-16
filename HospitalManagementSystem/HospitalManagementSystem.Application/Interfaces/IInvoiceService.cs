using HospitalManagementSystem.Application.DTOs.Invoice;

namespace HospitalManagementSystem.Application.Interfaces;

public interface IInvoiceService
{
    Task<InvoiceDto?> GetInvoiceAsync(int invoiceId);
    Task<IEnumerable<InvoiceDto>> GetInvoicesAsync();
    Task<IEnumerable<InvoiceDto>> GetInvoicesByPatientIdAsync(int patientId);
    Task<IEnumerable<InvoiceDto>> GetUnpaidInvoicesAsync();
    Task<int> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto);
    Task UpdateInvoiceAsync(UpdateInvoiceDto updateInvoiceDto);
    Task DeleteInvoiceAsync(int invoiceId);
}
