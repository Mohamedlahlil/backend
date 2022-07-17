using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;

namespace GPI.Data
{
    public class RoleRepo : IRoleRepo
    {
        private readonly GPIContext __context;

        public RoleRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            __context.Roles.Add(role);
        }



        public void DeleteRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            __context.Roles.Remove(role);
        }



        public IEnumerable<Role> GetAllRoles()
        {
            return __context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return __context.Roles.FirstOrDefault(p => p.IdRole == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateRole(Role role)
        {
            //Nothing
        }




    }
}