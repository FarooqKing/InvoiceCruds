using Invoice_Cruds.Iservice;
using InvoiceCruds.Iservice;

namespace InvoiceCruds.UnitOfWork
{
    public interface IUnitOfWork
    {
        IInvoiceDetail invoiceDetail { get; }
        ICity city { get; }
    }
}
