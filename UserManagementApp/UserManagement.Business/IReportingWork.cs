using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement.Business
{
    public interface IReportingWork
    {
        Task<List<UserModel>> UsersList();

        Task<UserModel> GetUser(int userId);
        Task<bool> UserExists(string email);
    }
}