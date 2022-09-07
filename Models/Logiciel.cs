using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class Logiciel
    {
        [Key]
        public int IdLogiciel { get; set; }

        [Required]
        public string Designation { get; set; }
        
        public string Source { get; set; }
        
        public string Licence { get; set; }
        
        public DateTime created_at { get; set; }
        
        public DateTime updated_at { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<AffHistorique> AffHistoriques { get; set; }
        
        public IEnumerable<AffLogiciel> AffLogiciels { get; set; }
        
    }
}