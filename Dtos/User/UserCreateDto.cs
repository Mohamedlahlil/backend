using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class UserCreateDto
    {   public string Login { get; set; }
        public string NomUser { get; set; }
        public string Passe { get; set; }
        public string Privilege { get; set; }
        public string Poste { get; set; }
        public int Dispo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string UUID { get; set; }
        public int IdService { get; set; }
    }
}