using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IReparationRepo
    {
        bool SaveChanges();
        IEnumerable<Reparation> GetAllReparations();
        Reparation GetReparationById(int id);
        void CreateReparation(Reparation reparation);
        void UpdateReparation(Reparation reparation);
        void DeleteReparation(Reparation reparation);
    }
}