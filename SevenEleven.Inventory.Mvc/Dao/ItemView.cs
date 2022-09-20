using SevenEleven.Inventory.Mvc.Models;

namespace SevenEleven.Inventory.Mvc.Dao
{
    public partial class ItemView
    {
       public Item item { get; set; }
       public User user { get; set; }
    }

}