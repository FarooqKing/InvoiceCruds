using InvoiceCruds.Models;

namespace InvoiceCruds.Iservice
{
    public interface IInvoiceDetail
    {
        Task<int> AddAsync(InvoiceDetail entity);
        Task<bool> UpdateAsync(InvoiceDetail entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<InvoiceDetail>> GetAllAsync();
        Task<InvoiceDetail?> GetByIdAsync(int id);
    }
}
