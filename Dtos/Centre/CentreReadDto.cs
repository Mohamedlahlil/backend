namespace GPI.Dtos
{
    public class CentreReadDto
    {

        public int IdCentre { get; set; }
        public string NomCentre { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public VilleReadDto Ville { get; set; }
        public int IdVille { get; set; }
    }
}