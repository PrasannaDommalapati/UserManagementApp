using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public interface IStory
    {
        Task<IEnumerable<UserModel>> UsersList();

        Task<UserModel> GetUser(int userId);

        Task CreateUser(UserModel userModel);
    }
}
