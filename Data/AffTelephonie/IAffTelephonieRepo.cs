using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IAffTelephonieRepo
    {
        bool SaveChanges();
        IEnumerable<AffTelephonie> GetAllAffTelephonies();
        AffTelephonie GetAffTelephonieById(int id);
        void CreateAffTelephonie(AffTelephonie affTelephonie);
        void UpdateAffTelephonie(AffTelephonie affTelephonie);
        void DeleteAffTelephonie(AffTelephonie affTelephonie);
    }
}