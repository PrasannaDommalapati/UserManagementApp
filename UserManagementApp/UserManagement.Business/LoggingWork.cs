using AutoMapper;
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
        private IMapper Mapper;

        public LoggingWork(IDataContext dataContext, IMapper mapper) : base(dataContext)
        {
            Mapper = mapper;
        }

        public Task AddOrganisationToUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task AddRoleToUserAsync()
        {
            throw new System.NotImplementedException();
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
