using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Models
{
    public class ReparationReadDto
    {
        
        public int IdReparation { get; set; }
        public string Pieceenvoie { get; set; }
        public string DescriptionReparation { get; set; }
        public bool EtatReparation { get; set; }
        public float MontantReparation { get; set; }
        public DateTime DateReception { get; set; }
        public DateTime Dateenvoie { get; set; }
        public DateTime SaisieLe { get; set; }
        public ArticleReadDto Article { get; set; }
        public int IdArticle { get; set; }
        public FournisseurReadDto Fournisseur { get; set; }
        public int IdFournisseur { get; set; }
        

    }
}