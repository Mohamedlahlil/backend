using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Statut { get; set; }
        [Required]
        public string Priorite { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Dateouverture { get; set; }
        [Required]
        public DateTime DateFin { get; set; }
        [Required]
        public DateTime DateDemande { get; set; }
        [Required]
        public string Solution { get; set; }
        [Required]
        public string Lieu { get; set; }
        [Required]
        public string Creepar { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }
        public User User { get; set; }
        public int IdUser { get; set; }
        public Article Article { get; set; }
        public int IdArticle { get; set; }
         public Logiciel Logiciel { get; set; }
        public int IdLogiciel { get; set; }
        public Telephonie Telephonie { get; set; }
        public int IdTelephonie { get; set; }

        public SousCategorie SousCategorie { get; set; }
        public int IdSousCat { get; set; }

        public IEnumerable<Pauses> Pausess { get; set; }

    }
}