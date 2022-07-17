using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class Service
    {
        [Key]
        public int IdService { get; set; }

        [Required]
        [MaxLength(250)]
        public string NomService { get; set; }

        public Centre Centre { get; set; }
        public int IdCentre { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<AffArticle> AffArticles { get; set; }

    }
}