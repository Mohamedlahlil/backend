using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ILogicielRepo
    {
        bool SaveChanges();
        IEnumerable<Logiciel> GetAllLogiciels();
        Logiciel GetLogicielById(int id);
        void CreateLogiciel(Logiciel logiciel);
        void UpdateLogiciel(Logiciel logiciel);
        void DeleteLogiciel(Logiciel logiciel);
    }
}