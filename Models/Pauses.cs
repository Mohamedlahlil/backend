using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPI.Models
{
    public class Pauses
    {
        [Key]
        public int IdPauses { get; set; }

        [Required]
        [MaxLength(250)]
        public string Raison { get; set; }
        [Required]
        public DateTime Dateouverture { get; set; }
        [Required]
        public DateTime Datefin { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

        public Ticket Ticket { get; set; }
        public int IdTicket { get; set; }
        
    }
}