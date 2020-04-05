using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public partial class Story : IStory
    {
        public Task<List<OrganisationModel>> Organisations()
        {
            throw new NotImplementedException();
        }

        public Task<OrganisationModel> Organisation(int userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrganisation(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrganisation(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
