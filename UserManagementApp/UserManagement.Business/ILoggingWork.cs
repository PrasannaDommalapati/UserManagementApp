using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement.Business
{
    public interface ILoggingWork
    {
        Task CreateUserAsync(UserModel userDto);

        Task CreateOrganisationAsync();

        Task AddOrganisationToUserAsync();

        Task AddRoleToUserAsync();
    }
}
