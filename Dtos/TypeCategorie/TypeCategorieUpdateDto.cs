using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GPI.Models
{
    public class TypeCategorieUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string TypeCat { get; set; }
    }
}