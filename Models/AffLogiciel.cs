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
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

        public User User { get; set; }
        public int IdUser { get; set; }
        
        public List<Logiciel> Logiciels { get; set; }
    }
}