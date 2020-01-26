using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.DataAccess.Entity
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int OrganisationId { get; set; }

        [Required]
        public string AddressLine { get; set; }
        
        [Required]
        public string TownOrCity { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string Postcode { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
