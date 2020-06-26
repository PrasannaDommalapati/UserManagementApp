using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public class OrganisationStory : IOrganisationStory
    {
        public Task CreateOrganisation(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrganisation(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrganisationModel>> Organisations()
        {
            throw new NotImplementedException();
        }

        public Task<OrganisationModel> GetOrganisation(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
