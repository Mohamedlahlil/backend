using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using GPI.Models;

namespace GPI.Models
{
    public class AffArticleCreateDto
    {
        public string Typeaffectation { get; set; }
        public DateTime dateaffectation { get; set; }
        public string Observation { get; set; }
        public int IdService { get; set; }
        public int IdUser { get; set; }
        
    }
}