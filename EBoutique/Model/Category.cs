using System.ComponentModel.DataAnnotations;

namespace EBoutique.Model
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }
        [MaxLength(55)]
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}