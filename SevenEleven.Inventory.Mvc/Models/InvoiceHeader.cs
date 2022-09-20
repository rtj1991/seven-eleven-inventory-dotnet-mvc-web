using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SevenEleven.Inventory.Mvc.Models
{
    public partial class InvoiceHeader
    {
        public InvoiceHeader(){
            CreatedDate=DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNo { get; set; }
        public string? PurchaserName { get; set; }

        public string? Description { get; set; }
        public string? Address { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public int PaidStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Created_by")]
        public string? Created_by { get; set; }

        [ForeignKey("Loc_Id")]
        public int? Loc_Id { get; set; }
    }

}