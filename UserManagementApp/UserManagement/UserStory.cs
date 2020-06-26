using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business;
using UserManagement.Business.Extensions;
using UserManagement.Business.Models;

namespace UserManagement
{
    public class UserStory : IUserStory
    {
        private readonly IReportingWork ReportingWork;

        private readonly ILoggingWork LoggingWork;

        public UserStory(ILoggingWork loggingWork, IReportingWork reportingWork)
        {
            LoggingWork = loggingWork.ValidateNotNull();
            ReportingWork = reportingWork.ValidateNotNull();
        }

        public async Task<List<UserModel>> UsersList()
        {
            return await ReportingWork
                .UsersList()
                .ConfigureAwait(false);
        }

        public async Task<UserModel> GetUser(int userId)
        {
            return await ReportingWork
                .GetUser(userId)
                .ConfigureAwait(false);
        }

        public async Task CreateUser(UserModel userModel)
        {
            var userExisted = await ReportingWork
                .UserExists(userModel.Email)
                .ConfigureAwait(false);

            if (userExisted)
                throw new UserManagementException("User already created in usermanagement");

            await LoggingWork
                .CreateUserAsync(userModel)
                .ConfigureAwait(false);
        }

        public async Task DeleteUser(int userId)
        {
            await LoggingWork
                .DeleteUserAsync(userId)
                .ConfigureAwait(false);
        }

        public async Task Update(UserModel userModel)
        {
            await LoggingWork
                .UpdateUserAsync(userModel)
                .ConfigureAwait(false);
        }

        public async Task UpdateActiveStatus(string userEmail, bool status)
        {
            await LoggingWork
                .UpdateActiveStatus(userEmail, status)
                .ConfigureAwait(false);
        }
    }
}