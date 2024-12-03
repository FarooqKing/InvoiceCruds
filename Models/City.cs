namespace InvoiceCruds.Models
{
    public class City
    {
        public int AreaId { get; set; }

        public string AreaName { get; set; } = null!;

        public bool? MDelete { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
