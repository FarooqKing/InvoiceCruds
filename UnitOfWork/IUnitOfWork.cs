using InvoiceCruds.Iservice;

namespace InvoiceCruds.UnitOfWork
{
    public interface IUnitOfWork
    {
        IInvoiceDetail invoiceDetail { get; }
    }
}
