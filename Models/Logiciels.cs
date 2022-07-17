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
        [Required]
        public string Source { get; set; }
        [Required]
        public string Licence { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

        public AffLogiciel AffLogiciel { get; set; }
        public int IdAffLogiciel { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<AffHistorique> AffHistoriques { get; set; }
        
    }
}