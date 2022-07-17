using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ITypeRepo
    {
        bool SaveChanges();
        IEnumerable<Type> GetAllTypes();
        Type GetTypeById(int id);
        void CreateType(Type type);
        void UpdateType(Type type);
        void DeleteType(Type type);
    }
}