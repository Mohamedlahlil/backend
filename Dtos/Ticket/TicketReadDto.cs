using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class TicketReadDto
    {
        
        public int IdTicket { get; set; }
        public string Type { get; set; }
        public string Statut { get; set; }
        public string Priorite { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime Dateouverture { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime DateDemande { get; set; }
        public string Solution { get; set; }
        public string Lieu { get; set; }
        public string Creepar { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public UserReadDto User { get; set; }
        public int IdUser { get; set; }
        public ArticleReadDto Article { get; set; }
        public int IdArticle { get; set; }
         public LogicielReadDto Logiciel { get; set; }
        public int IdLogiciel { get; set; }
        public TelephonieReadDto Telephonie { get; set; }
        public int IdTelephonie { get; set; }

        public SousCategorieReadDto SousCategorie { get; set; }
        public int IdSousCat { get; set; }

    }
}