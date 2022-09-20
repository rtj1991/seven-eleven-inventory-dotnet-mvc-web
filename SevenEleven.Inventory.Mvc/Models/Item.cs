using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SevenEleven.Inventory.Mvc.Models
{
    public partial class Item
    {
        public Item(){
            CreatedDate=DateTime.UtcNow;
        }

        public Item(int _id, string _name, string _description, double _price, int _status, DateTime _createdDate, string _createdBy)
        {
            this.Id = _id;
            this.Name = _name;
            this.Description = _description;
            this.Price = _price;
            this.Status = _status;
            this.CreatedDate = _createdDate;
            this.Created_by = _createdBy;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Created_by")]
        public string? Created_by { get; set; }

    }

}