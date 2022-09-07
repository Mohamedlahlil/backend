using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Models
{
    public class AffTelephonieReadDto
    {
        public int IdAffTelephonie { get; set; }
        public string Observation { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public CentreReadDto Centre { get; set; }
        public int IdCentre { get; set; }

        public TelephonieReadDto Telephonie { get; set; }
        public int IdTelephonie { get; set; }
    }
}