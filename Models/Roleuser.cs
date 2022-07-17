using System.ComponentModel.DataAnnotations;

namespace GPI.Models
{
    public class Roleuser
    {
        [Key]
        public int IdRoleuser { get; set; }

        public User User { get; set; }
        public int IdUser { get; set; }

        public Role Role { get; set; }
        public int IdRole { get; set; }
    }
}