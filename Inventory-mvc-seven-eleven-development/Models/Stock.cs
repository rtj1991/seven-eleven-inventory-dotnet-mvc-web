using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Inventory_mvc_seven_eleven.Models
{
    public partial class Stock
    {
        public Stock()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public Stock(int _id,string _description,double _quantity ,int _status,bool _stockAvailable, DateTime _createdDate,DateTime _expireDate,int _itemCode,int _locationId, string _createdBy,string _modifiedBy)
        {
            this.Id = _id;
            this.Description = _description;
            this.Quantity = _quantity;
            this.Status = _status;
            this.StockAvailable = _stockAvailable;
            this.CreatedDate = _createdDate;
            this.ExpireDate = _expireDate;
            this.Item_code = _itemCode;
            this.Location_id = _locationId;
            this.Created_by = _createdBy;
            this.Modified_by = _modifiedBy;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public double Quantity { get; set; }
        public int? Status { get; set; }
        public bool StockAvailable { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ExpireDate { get; set; }

        [ForeignKey("Item_code")]
        public int? Item_code { get; set; }

        [ForeignKey("Location_id")]
        public int? Location_id { get; set; }

        [ForeignKey("Created_by")]
        public string? Created_by { get; set; }

        public string? Modified_by { get; set; }
    }

}