using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IAffLogicielRepo
    {
        bool SaveChanges();
        IEnumerable<AffLogiciel> GetAllAffLogiciels();
        AffLogiciel GetAffLogicielById(int id);
        void CreateAffLogiciel(AffLogiciel affLogiciel);
        void UpdateAffLogiciel(AffLogiciel affLogiciel);
        void DeleteAffLogiciel(AffLogiciel affLogiciel);
    }
}