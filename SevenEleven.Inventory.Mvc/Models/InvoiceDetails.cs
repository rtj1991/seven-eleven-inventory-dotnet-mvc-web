using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SevenEleven.Inventory.Mvc.Models
{
    public partial class InvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Quentity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Item_Code")]
        public int? Item_Code { get; set; }

        [ForeignKey("Inv_no")]
        public int? Inv_no { get; set; }

    }

}