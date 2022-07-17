using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IServiceRepo
    {
        bool SaveChanges();
        IEnumerable<Service> GetAllServices();
        Service GetServiceById(int id);
        void CreateService(Service service);
        void UpdateService(Service service);
        void DeleteService(Service service);
    }
}