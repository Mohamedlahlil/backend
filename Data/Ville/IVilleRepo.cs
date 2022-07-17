using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IVilleRepo
    {
        bool SaveChanges();
        IEnumerable<Ville> GetAllVilles();
        Ville GetVilleById(int id);
        void CreateVille(Ville vl);
        void UpdateVille(Ville vl);
        void DeleteVille(Ville vl);
    }
}