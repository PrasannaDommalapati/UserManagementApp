using System;

namespace UserManagement.Business.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime DateModified { get; set; }
    }
}
