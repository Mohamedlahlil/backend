using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using GPI.Models;

namespace GPI.Models
{
    public class AffArticle
    {
        [Key]
        public int IdAffArticle { get; set; }

        
        [MaxLength(250)]
        public string Typeaffectation { get; set; }
        
        public DateTime dateaffectation { get; set; }
        
        public string Observation { get; set; }

        public Service Service { get; set; }
        public int IdService { get; set; }
        public User User { get; set; }
        public int IdUser { get; set; }

       public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        
    }
}