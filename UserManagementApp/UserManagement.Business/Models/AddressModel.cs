using System;

namespace UserManagement.Business.Models
{
    public class AddressModel
    {
        public int OrganisationId { get; set; }

        public string AddressLine { get; set; }
        
        public string TownOrCity { get; set; }

        public string County { get; set; }

        public string Postcode { get; set; }

        public DateTime DateModified { get; set; }
    }
}