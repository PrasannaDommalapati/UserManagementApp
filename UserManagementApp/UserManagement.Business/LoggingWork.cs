using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagement.DataAccess;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business
{
    public class LoggingWork : UnitOfWork, ILoggingWork
    {
        public LoggingWork(IDataContext dataContext) : base(dataContext)
        {
        }

        public Task AddOrganisationToUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddRoleToUserAsync(int userId, UserRole role)
        {
            var user = await DataContext
                .Users
                .Include("Roles")
                .FirstOrDefaultAsync(a => a.Id == userId)
                .ConfigureAwait(false);

            user.Roles.Add(role);

            await DataContext
                .Users
                .AddAsync(user)
                .ConfigureAwait(false);

            await DataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public Task CreateOrganisationAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateUserAsync(UserModel userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Birthday = userDto.Birthday,
                DateCreated = DateTime.UtcNow.Date,
                DateModified = DateTime.UtcNow.Date,
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Role = nameof(UserRoleTypes.User)
                    }
                }
            };

            await DataContext
                .Users
                .AddAsync(user)
                .ConfigureAwait(false);

            await DataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await DataContext
                .Users
                .Include(d => d.Roles)
                .Include(d => d.Organisations)
                .FirstOrDefaultAsync(d => d.Id == userId)
                .ConfigureAwait(false);

            DataContext.Users.Remove(user);

            await DataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateUserAsync(UserModel userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Birthday = userDto.Birthday,
                Organisations = userDto.Organisations,
                Roles = userDto.Roles,
                DateCreated = DateTime.UtcNow.Date,
                DateModified = DateTime.UtcNow.Date
            };

            DataContext
               .Users
               .Update(user);

            await DataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }
    }
}
