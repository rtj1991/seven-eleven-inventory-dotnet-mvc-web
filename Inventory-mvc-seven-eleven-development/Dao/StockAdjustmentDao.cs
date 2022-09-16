namespace Inventory_mvc_seven_eleven.Models
{
    public partial class StockAdjustmentDao
    {
        public StockAdjustmentDao(string v1, double v2, int v3, int v4, int v5)
        {
            AdjustDescription = v1;
            Qty = v2;
            Item_code = v3;
            Location_id = v4;
            Stock_Id = v5;
        }

        public string? AdjustDescription { get; set; }
        public double Qty { get; set; }
        public int? Item_code { get; set; }
        public int? Location_id { get; set; }
        public int Stock_Id { get; set; }
    }

}