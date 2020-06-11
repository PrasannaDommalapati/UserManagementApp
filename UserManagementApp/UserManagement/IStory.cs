using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public interface IStory
    {
        Task<List<OrganisationModel>> Organisations();

        Task<OrganisationModel> GetOrganisation(int userId);

        Task DeleteOrganisation(int userId);

        Task CreateOrganisation(UserModel userModel);
    }
}
