using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business;
using UserManagement.Business.Models;

namespace UserManagement
{
    public class Story : IStory
    {
        private readonly IReportingWork ReportingWork;

        private readonly ILoggingWork LoggingWork;

        public Story(ILoggingWork loggingWork, IReportingWork reportingWork)
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
            await LoggingWork
                .CreateUserAsync(userModel)
                .ConfigureAwait(false);
        }

        public Task<List<OrganisationModel>> Organisations()
        {
            throw new NotImplementedException();
        }

        public Task<OrganisationModel> Organisation(int userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrganisation(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrganisation(int userId)
        {
            throw new NotImplementedException();
        }
    }
}