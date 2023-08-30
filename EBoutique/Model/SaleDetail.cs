
using System.ComponentModel.DataAnnotations;


namespace EBoutique.Model
{
    public class SaleDetail
    {
        [Key]
        public int SaleDetailId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // Foreign Key
        public int ProductId { get; set; }
        // Foreign Key
        public int SaleId { get; set; }
        // Navigation property
        public Sale Sale { get; set; }
        // Navigation property
        public Product Product { get; set; }
    }
}