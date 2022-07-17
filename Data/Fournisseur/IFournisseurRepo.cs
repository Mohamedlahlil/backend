using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IFournisseurRepo
    {
        bool SaveChanges();
        IEnumerable<Fournisseur> GetAllFournisseurs();
        Fournisseur GetFournisseurById(int id);
        void CreateFournisseur(Fournisseur vl);
        void UpdateFournisseur(Fournisseur vl);
        void DeleteFournisseur(Fournisseur vl);
    }
}