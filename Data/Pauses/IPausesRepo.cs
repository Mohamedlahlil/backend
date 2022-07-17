using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IPausesRepo
    {
        bool SaveChanges();
        IEnumerable<Pauses> GetAllPausess();
        Pauses GetPausesById(int id);
        void CreatePauses(Pauses pauses);
        void UpdatePauses(Pauses pauses);
        void DeletePauses(Pauses pauses);
    }
}