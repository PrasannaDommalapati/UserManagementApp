using System;

namespace UserManagement.Business.Models
{
    public class OrganisationModel
    {
        public string OrganisationName { get; set; }

        public AddressModel AddressModel { get; set; }

        public string Licence { get; set; }

        public DateTime DateModified { get; set; }
    }
}
