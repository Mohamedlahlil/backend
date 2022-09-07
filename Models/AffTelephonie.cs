using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GPI.Models;

namespace GPI.Models
{
    public class AffTelephonie
    {
        [Key]
        public int IdAffTelephonie { get; set; }

        [Required]
        [MaxLength(250)]
        public string Observation { get; set; }
        
        public DateTime created_at { get; set; }
        
        public DateTime updated_at { get; set; }

        public Centre Centre { get; set; }
        public int IdCentre { get; set; }
        public Telephonie Telephonie { get; set; }
        public int IdTelephonie { get; set; }

       // public List<Telephonie> Telephonies { get; set; }
        
    }
}