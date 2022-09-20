using SevenEleven.Inventory.Mvc.Models;

namespace SevenEleven.Inventory.Mvc.Dao
{
    public partial class StockView
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public bool StockAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Qty { get; set; }
        public Item item { get; set; }
        public Location location { get; set; }
        public User user { get; set; }

    }

}