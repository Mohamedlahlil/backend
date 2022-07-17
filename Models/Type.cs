using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class Type
    {
        [Key]
        public int IdType { get; set; }

        [Required]
        public string Designation { get; set; }
      
        public IEnumerable<Article> Articles { get; set; }
    }
}