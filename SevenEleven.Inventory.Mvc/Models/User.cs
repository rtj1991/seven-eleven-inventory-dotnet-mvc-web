using Microsoft.AspNetCore.Identity;

namespace SevenEleven.Inventory.Mvc.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            CreatedDate=DateTime.UtcNow;
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
