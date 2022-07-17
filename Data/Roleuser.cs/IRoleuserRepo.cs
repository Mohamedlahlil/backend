using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IRoleuserRepo
    {
        bool SaveChanges();
        IEnumerable<Roleuser> GetAllRoleusers();
        Roleuser GetRoleuserById(int id);
        void CreateRoleuser(Roleuser roleuser);
        void UpdateRoleuser(Roleuser roleuser);
        void DeleteRoleuser(Roleuser roleuser);
    }
}