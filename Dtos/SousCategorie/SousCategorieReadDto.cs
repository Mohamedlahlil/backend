using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GPI.Dtos;

namespace GPI.Models
{
    public class SousCategorieReadDto
    {
        
        public int IdSousCat { get; set; }
        public string Libelle { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public CategorieReadDto Categorie { get; set; }
        public int IdCategorie { get; set; }
        public TypeCategorieReadDto TypeCategorie { get; set; }
        public int IdTypeCategorie { get; set; }
    }
}