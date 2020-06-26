using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public interface IUserStory
    {
        Task<List<UserModel>> UsersList();

        Task<UserModel> GetUser(int userId);

        Task DeleteUser(int userId);

        Task CreateUser(UserModel userModel);

        Task Update(UserModel userModel);

        Task UpdateActiveStatus(string userEmail, bool status);
    }
}