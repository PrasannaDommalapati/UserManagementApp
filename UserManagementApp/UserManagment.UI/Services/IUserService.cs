using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagment.UI.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
    }
}