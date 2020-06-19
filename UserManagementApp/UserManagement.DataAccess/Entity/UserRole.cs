using System.ComponentModel.DataAnnotations;

namespace UserManagement.DataAccess.Entity
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        public string Role { get; set; }
    }
}