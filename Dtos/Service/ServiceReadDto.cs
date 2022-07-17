using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Models
{
    public class ServiceReadDto
    {
        
        public int IdService { get; set; }
        public string NomService { get; set; }

        public CentreReadDto Centre { get; set; }
        public int IdCentre { get; set; }

    }
}