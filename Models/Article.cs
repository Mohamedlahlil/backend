using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class Article
    {
        [Key]
        public int IdArticle { get; set; }
        [Required]
        public string CodeInterne { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public string Numserie { get; set; }
        [Required]
        public string CodeLicence { get; set; }
        [Required]
        public bool Licence { get; set; }
        [Required]
        public float Prix { get; set; }
        [Required]
        public DateTime DateAchat { get; set; }
        [Required]
        public bool Reforme { get; set; }
        [Required]
        public string NumCommande { get; set; }
        [Required]
        public string NumFacture { get; set; }
        public Type Type { get; set; }
        public int IdType { get; set; }
        public AffArticle AffArticle { get; set; }
        public int IdAffArticle { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public int IdFournisseur { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Reparation> Reparations { get; set; }
        public IEnumerable<AffHistorique> AffHistoriques { get; set; }

    }
}