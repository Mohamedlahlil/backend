using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        [MaxLength(250)]
        public string Login { get; set; }
        [Required]
        public string NomUser { get; set; }
        [Required]
        public string Passe { get; set; }
        [Required]
        public string Privilege { get; set; }
        [Required]
        public string Poste { get; set; }
        [Required]
        public int Dispo { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }
        [Required]
        public string UUID { get; set; }

        public Service Service { get; set; }
        public int IdService { get; set; }

        public IEnumerable<Roleuser> Roleusers { get; set; }
        public IEnumerable<AffArticle> AffArticles { get; set; }
        public IEnumerable<AffLogiciel> AffLogiciels { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<AffHistorique> AffHistoriques { get; set; }
    }
}