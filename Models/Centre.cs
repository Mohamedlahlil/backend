using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GPI.Models
{
    public class Centre
    {
        [Key]
        public int IdCentre { get; set; }

        [Required]
        [MaxLength(250)]
        public string NomCentre { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string Telephone { get; set; }

        public Ville Ville { get; set; }
        public int IdVille { get; set; }

        public List<Service> Services { get; set; }
        public List<AffTelephonie> AffTelephonies { get; set; }
        
    }
}