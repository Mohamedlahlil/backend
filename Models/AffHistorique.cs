using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class AffHistorique
    {
        [Key]
        public int IdHistorique { get; set; }
        [Required]
        public string TypeAffectation { get; set; }
        [Required]
        public string Observation { get; set; }
        [Required]
        public DateTime Daterecuperation { get; set; }
        [Required]
        public DateTime DateAffectation { get; set; }
        public User User { get; set; }
        public int IdUser { get; set; }
        public Article Article { get; set; }
        public int IdArticle { get; set; }
         public Logiciel Logiciel { get; set; }
        public int IdLogiciel { get; set; }
        public Telephonie Telephonie { get; set; }
        public int IdTelephonie { get; set; }
    }
}