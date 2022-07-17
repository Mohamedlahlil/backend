using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using GPI.Models;

namespace GPI.Models
{
    public class AffArticleReadDto
    {
        public int IdAffArticle { get; set; }
        public string Typeaffectation { get; set; }
        public DateTime dateaffectation { get; set; }
        public string Observation { get; set; }
        public ServiceReadDto Service { get; set; }
        public int IdService { get; set; }
        public UserReadDto User { get; set; }
        public int IdUser { get; set; }
        
    }
}