using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class Reparation
    {
        [Key]
        public int IdReparation { get; set; }
        [Required]
        public string Pieceenvoie { get; set; }
        [Required]
        public string DescriptionReparation { get; set; }
        [Required]
        public bool EtatReparation { get; set; }
        [Required]
        public float MontantReparation { get; set; }
        [Required]
        public DateTime DateReception { get; set; }
        [Required]
        public DateTime Dateenvoie { get; set; }
        [Required]
        public DateTime SaisieLe { get; set; }
        public Article Article { get; set; }
        public int IdArticle { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public int IdFournisseur { get; set; }
        

    }
}