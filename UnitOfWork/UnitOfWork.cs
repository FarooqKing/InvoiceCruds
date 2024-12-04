using Invoice_Cruds.Iservice;
using InvoiceCruds.Iservice;

namespace InvoiceCruds.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {

        public IInvoiceDetail invoiceDetail { get; set; }
        public ICity city{ get; set; }

        public UnitOfWork(IInvoiceDetail invoiceDetails, ICity city)
        {
            invoiceDetail = invoiceDetails;
            this.city = city;
        }

    }
}
