using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.DataAccess.Entity
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }

        public string Role { get; set; }
    }
}