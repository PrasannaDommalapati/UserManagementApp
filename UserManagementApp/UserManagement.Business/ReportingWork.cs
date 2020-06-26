using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagement.DataAccess;

namespace UserManagement.Business
{
    public class ReportingWork : IReportingWork
    {
        private readonly IMapper _mapper;
        private UserDataContext _dataContext { get; set; }

        public ReportingWork(UserDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> UsersList()
        {
            var users = new List<UserModel>();

            var usersList = await _dataContext
                .Users
                .Include("Roles")
                .Include("Organisations")
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var user in usersList)
            {
                users.Add(_mapper.Map<UserModel>(user));
            }

            return users;
        }

        public async Task<UserModel> GetUser(int userId)
        {
            var users = await _dataContext
                .Users
                .ToListAsync()
                .ConfigureAwait(false);

            return _mapper.Map<UserModel>(users.Find(u => u.Id == userId));
        }

        public async Task<bool> UserExists(string email)
        {
            return await _dataContext
                .Users
                .AnyAsync(u => u.Email == email)
                .ConfigureAwait(false);
        }
    }
}
