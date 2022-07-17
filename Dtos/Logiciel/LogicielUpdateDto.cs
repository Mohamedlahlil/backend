using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class LogicielUpdateDto
    {
        public string Designation { get; set; }
        public string Source { get; set; }
        public string Licence { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int IdAffLogiciel { get; set; }
        
    }
}