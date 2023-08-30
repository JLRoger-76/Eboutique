using System.ComponentModel.DataAnnotations;

namespace EBoutique.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        // Foreign Key
        public int CategoryId { get; set; }
        // Navigation property
        public Category Category { get; set; }

    }
}