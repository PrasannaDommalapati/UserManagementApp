using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagement.DataAccess;

namespace UserManagement.Business
{
    public class ReportingWork : UnitOfWork, IReportingWork
    {
        private readonly IMapper Mapper;

        public ReportingWork(IDataContext dataContext, IMapper mapper) : base(dataContext)
        {
            Mapper = mapper;
        }

        public async Task<List<UserModel>> UsersList()
        {
            var users = new List<UserModel>();

            var usersList = await DataContext
                .Users
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var user in usersList)
            {
                users.Add(Mapper.Map<UserModel>(user));
            }

            return users;
        }
    }
}
