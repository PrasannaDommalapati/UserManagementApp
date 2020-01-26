using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public interface IStory
    {
        Task<List<UserModel>> UsersList();

        Task CreateUser(UserModel userDto);
    }
}
