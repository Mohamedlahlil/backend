using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class TelephonieUpdateDto
    {
        public string Lignesupport { get; set; }
        public string Typeliaison { get; set; }
        public string Autreinformations { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        
    }
}