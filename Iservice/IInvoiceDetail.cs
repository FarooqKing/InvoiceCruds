using Invoice_Cruds.Iservice;
using InvoiceCruds.Models;

namespace InvoiceCruds.Iservice
{
    public interface IInvoiceDetail :IGeneric<InvoiceDetail>
    {
      
        Task<InvoiceDetail?> GetReportByIdAsync(int id);
    }
}
