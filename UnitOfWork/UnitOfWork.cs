using InvoiceCruds.Iservice;

namespace InvoiceCruds.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {

        public IInvoiceDetail invoiceDetail { get; set; }

        public UnitOfWork(IInvoiceDetail invoiceDetails)
        {
            invoiceDetail = invoiceDetails;
        }

    }
}
