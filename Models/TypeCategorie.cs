using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GPI.Models
{
    public class TypeCategorie
    {
        [Key]
        public int IdTypeCategorie { get; set; }

        [Required]
        [MaxLength(250)]
        public string TypeCat { get; set; }

        public List<SousCategorie> SousCategories { get; set; }
    }
}