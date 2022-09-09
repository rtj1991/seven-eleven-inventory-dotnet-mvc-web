namespace Inventory_mvc_seven_eleven.Models
{
    public partial class InvoiceRequest
    {
        public string? PurchaserName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public double PaidAmount { get; set; }
        public string? Created_by { get; set; }
        public int? Loc_Id { get; set; }
        public ICollection<InvoiceRequestDetails>? invoiceRequestDetails { get; set; }
        
    }

}