using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IAffHistoriqueRepo
    {
        bool SaveChanges();
        IEnumerable<AffHistorique> GetAllAffHistoriques();
        AffHistorique GetAffHistoriqueById(int id);
        void CreateAffHistorique(AffHistorique affHistorique);
        void UpdateAffHistorique(AffHistorique affHistorique);
        void DeleteAffHistorique(AffHistorique affHistorique);
    }
}