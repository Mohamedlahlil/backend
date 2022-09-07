using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GPI.Models;

namespace GPI.Models
{
    public class AffLogiciel
    {
        [Key]
        public int IdAffLogiciel { get; set; }

        [Required]
        [MaxLength(250)]
        public string Observation { get; set; }
        
        public DateTime created_at { get; set; }
        
        public DateTime updated_at { get; set; }

        public User User { get; set; }
        public int IdUser { get; set; }
        public Logiciel Logiciel { get; set; }
        public int IdLogiciel { get; set; }
        
        //public List<Logiciel> Logiciels { get; set; }
    }
}