using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Models
{
    public class ArticleUpdateDto
    {
        
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
        public int IdType { get; set; }
        public int IdAffArticle { get; set; }
        public int IdFournisseur { get; set; }

    }
}