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
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public DateTime Birthday { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }
     
        public DateTime DateModified { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }
    }
}
