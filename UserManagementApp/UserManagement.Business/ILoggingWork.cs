using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business
{
    public interface ILoggingWork
    {
        Task CreateUserAsync(UserModel userDto);
        
        Task UpdateUserAsync(UserModel userDto);

        Task CreateOrganisationAsync();

        Task AddOrganisationToUserAsync();

        Task AddRoleToUserAsync(int userId, UserRole role);

        Task DeleteUserAsync(int userId);
    }
}
