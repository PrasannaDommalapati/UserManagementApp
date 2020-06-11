using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement
{
    public interface IUser
    {
        Task<List<UserModel>> UsersList();

        Task<UserModel> GetUser(Guid userId);

        Task DeleteUser(Guid userId);

        Task CreateUser(UserModel userModel);
    }
}