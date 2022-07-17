using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ITelephonieRepo
    {
        bool SaveChanges();
        IEnumerable<Telephonie> GetAllTelephonies();
        Telephonie GetTelephonieById(int id);
        void CreateTelephonie(Telephonie telephonie);
        void UpdateTelephonie(Telephonie telephonie);
        void DeleteTelephonie(Telephonie telephonie);
    }
}