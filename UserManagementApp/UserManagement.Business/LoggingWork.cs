using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagement.DataAccess;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business
{
    public class LoggingWork : UnitOfWork, ILoggingWork
    {
        private readonly IMapper Mapper;

        public LoggingWork(IDataContext dataContext, IMapper mapper) : base(dataContext)
        {
            Mapper = mapper;
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
    }
}
