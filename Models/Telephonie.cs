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
        
        public string Autreinformations { get; set; }
        
        public DateTime created_at { get; set; }
        
        public DateTime updated_at { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<AffHistorique> AffHistoriques { get; set; }
        
        public IEnumerable<AffTelephonie> AffTelephonies { get; set; }
        
    }
}