using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public interface IStory
    {
        Task<List<UserModel>> UsersList();

        Task<UserModel> GetUser(int userId);

        Task DeleteUser(int userId);

        Task CreateUser(UserModel userModel);

        Task<List<OrganisationModel>> Organisations();

        Task<OrganisationModel> Organisation(int userId);

        Task DeleteOrganisation(int userId);

        Task CreateOrganisation(UserModel userModel);
    }
}
