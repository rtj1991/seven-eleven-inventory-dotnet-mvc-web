using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SevenEleven.Inventory.Mvc.Models
{
    public partial class StockAdjustment
    {
        public StockAdjustment()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public double Quantity { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Item_code")]
        public int? Item_code { get; set; }

        [ForeignKey("Location_id")]
        public int? Location_id { get; set; }

        [ForeignKey("Created_by")]
        public string? Created_by { get; set; }

        [ForeignKey("Modified_by")]
        public string? Modified_by { get; set; }

        [ForeignKey("Stock_Id")]
        public int Stock_Id { get; set; }

    }

}