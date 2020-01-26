using System.ComponentModel.DataAnnotations;

namespace UserManagement.DataAccess.Entity
{
    public class RoleTypes
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public enum UserRoleTypes
    {
        Admin = 2,
        SuperAdmin = 1,
        User = 3,
        Client = 4
    }
}
