using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class Ville
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string NomVille { get; set; }

        public List<Centre> Centres { get; set; }
    }
}