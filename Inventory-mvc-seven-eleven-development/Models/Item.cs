using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_mvc_seven_eleven.Models
{
    public partial class Item
    {
        private int v1;
        private string v2;
        private string v3;
        private double v4;
        private int v5;
        private object utcNow;
        private string v6;
        private object value;

        public Item(){
            CreatedDate=DateTime.UtcNow;
        }

        public Item(int v1, string v2, string v3, double v4, int v5, object utcNow, string v6, object value)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.utcNow = utcNow;
            this.v6 = v6;
            this.value = value;
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