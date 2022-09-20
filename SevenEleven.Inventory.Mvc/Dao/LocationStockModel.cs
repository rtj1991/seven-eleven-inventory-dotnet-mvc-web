using SevenEleven.Inventory.Mvc.Models;

namespace SevenEleven.Inventory.Mvc.Dao
{
    public partial class LocationStockModel
    {
        public List<Location>? Locations { get; set; }

        public List<Item>? Items { get; set; }
        public Stock? Stocks { get; set; }

    }

}