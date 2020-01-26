using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.DataAccess.Entity
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public DateTime DateCreated { get; set; }
        
        public DateTime DateModified { get; set; }

        public virtual List<UserRole> Roles { get; set; }

        public virtual List<Organisation> Organisations { get; set; }
    }
}
