using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class TypeUpdateDto
    {
        public int IdType { get; set; }
        public string Designation { get; set; }
    }
}