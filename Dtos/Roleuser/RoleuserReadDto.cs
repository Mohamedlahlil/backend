using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class RoleuserReadDto
    {
       
        public int IdRoleuser { get; set; }

        public UserReadDto User { get; set; }
        public int IdUser { get; set; }

        public RoleReadDto Role { get; set; }
        public int IdRole { get; set; }
    }
}