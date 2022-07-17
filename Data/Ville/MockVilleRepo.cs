using System.Collections.Generic;
using GPI.Data;
using GPI.Models;

namespace CommaGPInder.Data
{
    public class MockVilleRepo : IVilleRepo
    {
        public void CreateVille(Ville vl)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteVille(Ville vl)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ville> GetAllVilles()
        {
            var villes = new List<Ville>
            {
                new Ville{Id=0, NomVille="Boil"},
                new Ville{Id=1, NomVille="cut"},
                new Ville{Id=2, NomVille="make"}
            };
            return villes;
        }

        public Ville GetVilleById(int id)
        {
            return new Ville { Id = 0, NomVille = "Boil" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateVille(Ville vl)
        {
            throw new System.NotImplementedException();
        }
    }
}