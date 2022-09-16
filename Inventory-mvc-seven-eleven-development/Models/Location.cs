using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_mvc_seven_eleven.Models
{
    public partial class Location
    {
        public Location()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public Location(int _id, string _name, string _description, int _status, DateTime _createdDate, string _createdBy)
        {
            Id = _id;
            Name = _name;
            Description = _description;
            Status = _status;
            CreatedDate = _createdDate;
            Created_by = _createdBy;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Created_by")]
        public string? Created_by { get; set; }
    }

}