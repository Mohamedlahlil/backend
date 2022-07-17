using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class ServiceUpdateDto
    {
        public string NomService { get; set; }
        public int IdCentre { get; set; }

    }
}