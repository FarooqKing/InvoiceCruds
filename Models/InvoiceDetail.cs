namespace InvoiceCruds.Models
{
    public partial class InvoiceDetail
    {
        public int InvoiceNo { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal? Discount1 { get; set; }

        public decimal? Discount2 { get; set; }

        public decimal? AddTax { get; set; }

        public DateTime Date { get; set; }

        public int AreaId { get; set; }

        public string BatchNo { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool MDelete { get; set; }

        public virtual City Area { get; set; } = null!;
    }
}
