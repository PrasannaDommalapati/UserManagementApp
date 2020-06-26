using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagement.DataAccess;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business
{
    public class LoggingWork : ILoggingWork
    {
        private UserDataContext _dataContext { get; set; }

        public LoggingWork(UserDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddOrganisationToUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddRoleToUserAsync(int userId, UserRole role)
        {
            var user = await _dataContext
                .Users
                .Include("Roles")
                .FirstOrDefaultAsync(a => a.Id == userId)
                .ConfigureAwait(false);

            user.Roles.Add(role);

            await _dataContext
                .Users
                .AddAsync(user)
                .ConfigureAwait(false);

            await _dataContext
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
                IsActive = false,
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

            await _dataContext
                .Users
                .AddAsync(user)
                .ConfigureAwait(false);

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _dataContext
                .Users
                .Include(d => d.Roles)
                .Include(d => d.Organisations)
                .FirstOrDefaultAsync(d => d.Id == userId)
                .ConfigureAwait(false);

            _dataContext.Users.Remove(user);

            await _dataContext
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
                IsActive = userDto.IsActive,
                DateCreated = DateTime.UtcNow.Date,
                DateModified = DateTime.UtcNow.Date
            };

            _dataContext
               .Users
               .Update(user);

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateActiveStatus(string userEmail, bool status)
        {
            var user = await _dataContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == userEmail)
                .ConfigureAwait(false);

            user.IsActive = status;

            _dataContext.Users.Attach(user).State = EntityState.Modified;

            await _dataContext
                .UpdateAsync()
                .ConfigureAwait(false);
        }
    }
}
