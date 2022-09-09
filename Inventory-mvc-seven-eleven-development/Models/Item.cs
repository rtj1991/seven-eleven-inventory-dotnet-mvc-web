using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_mvc_seven_eleven.Models
{
    public partial class Item
    {
         public Item(){
            CreatedDate=DateTime.UtcNow;
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