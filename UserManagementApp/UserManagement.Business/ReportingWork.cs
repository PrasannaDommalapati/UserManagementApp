using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
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
                .Include("Roles")
                .Include("Organisations")
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var user in usersList)
            {
                users.Add(Mapper.Map<UserModel>(user));
            }

            return users;
        }

        public async Task<UserModel> GetUser(Guid userId)
        {
            var users = await DataContext
                .Users
                .ToListAsync()
                .ConfigureAwait(false);

            return Mapper.Map<UserModel>(users.Find(u => u.Id == userId));
        }
    }
}
