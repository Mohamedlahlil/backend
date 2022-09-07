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
        
        public string CodeInterne { get; set; }
        
        public string Reference { get; set; }
        
        public string Numserie { get; set; }
        
        public string CodeLicence { get; set; }
        
        public bool Licence { get; set; }
        
        public float Prix { get; set; }
        
        public DateTime DateAchat { get; set; }
        
        public bool Reforme { get; set; }
        
        public string NumCommande { get; set; }
        
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