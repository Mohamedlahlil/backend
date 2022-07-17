using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class ServiceCreateDto
    {   public string NomService { get; set; }
        public int IdCentre { get; set; }

    }
}