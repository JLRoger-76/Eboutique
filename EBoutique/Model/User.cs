using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBoutique.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(20)]
        public string Pseudo { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}