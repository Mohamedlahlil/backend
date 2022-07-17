using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class PausesUpdateDto
    {
        
        public string Raison { get; set; }
        public DateTime Dateouverture { get; set; }
        public DateTime Datefin { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int IdTicket { get; set; }
        
    }
}