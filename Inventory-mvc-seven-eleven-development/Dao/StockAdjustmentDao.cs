namespace Inventory_mvc_seven_eleven.Models
{
    public partial class StockAdjustmentDao
    {
        public string? AdjustDescription { get; set; }
        public double Qty { get; set; }
        public int? Item_code { get; set; }
        public int? Location_id { get; set; }
        public int Stock_Id { get; set; }

    }

}