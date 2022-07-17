using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using GPI.Models;

namespace GPI.Models
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }

        [Required]
        [MaxLength(250)]
        public string Libelle { get; set; }

        public List<SousCategorie> SousCategories { get; set; }
    }
}