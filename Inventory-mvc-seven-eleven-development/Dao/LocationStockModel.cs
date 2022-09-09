using Inventory_mvc_seven_eleven.Models;

namespace Inventory_mvc_seven_eleven.Dao
{
    public partial class LocationStockModel
    {
        public List<Location>? Locations { get; set; }

        public List<Item>? Items { get; set; }
        public Stock? Stocks { get; set; }

    }

}