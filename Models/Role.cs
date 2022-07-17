using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required]
        [MaxLength(250)]
        public string Designation { get; set; }

        public List<Roleuser> Roleusers { get; set; }
    }
}