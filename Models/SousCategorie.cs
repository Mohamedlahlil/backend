using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class SousCategorie
    {
        [Key]
        public int IdSousCat { get; set; }

        [Required]
        [MaxLength(250)]
        public string Libelle { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

        public Categorie Categorie { get; set; }
        public int IdCategorie { get; set; }

        public TypeCategorie TypeCategorie { get; set; }
        public int IdTypeCategorie { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }

    }
}