using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GPI.Models;

namespace GPI.Models
{
    public class AffLogicielReadDto
    {
        public int IdAffLogiciel { get; set; }
        public string Observation { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public UserReadDto User { get; set; }
        public int IdUser { get; set; }
    }
}