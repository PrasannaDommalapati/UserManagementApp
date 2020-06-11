using System;
using System.Collections.Generic;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime DateModified { get; set; }

        public List<UserRole> Roles { get; set; }

        public List<Organisation> Organisations { get; set; }
    }
}
