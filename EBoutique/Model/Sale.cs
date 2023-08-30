using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EBoutique.Model
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}