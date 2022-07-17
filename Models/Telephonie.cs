using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class Telephonie
    {
        [Key]
        public int IdTelephonie { get; set; }

        [Required]
        public string Lignesupport { get; set; }
        [Required]
        public string Typeliaison { get; set; }
        [Required]
        public string Autreinformations { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

        public AffTelephonie AffTelephonie { get; set; }
        public int IdAffTelephonie { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<AffHistorique> AffHistoriques { get; set; }
        
    }
}