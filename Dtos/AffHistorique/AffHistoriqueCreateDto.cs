using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class AffHistoriqueCreateDto
    {
        public string TypeAffectation { get; set; }
        public string Observation { get; set; }
        public DateTime Daterecuperation { get; set; }
        public DateTime DateAffectation { get; set; }
        public int IdUser { get; set; }
        public int IdArticle { get; set; }
        public int IdLogiciel { get; set; }
        public int IdTelephonie { get; set; }
    }
}