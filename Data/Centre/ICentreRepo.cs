using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ICentreRepo
    {
        bool SaveChanges();
        IEnumerable<Centre> GetAllCentres();
        Centre GetCentreById(int id);
        void CreateCentre(Centre centre);
        void UpdateCentre(Centre centre);
        void DeleteCentre(Centre centre);
    }
}