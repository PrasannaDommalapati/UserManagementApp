using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement.Business
{
    public interface IReportingWork : IDisposable
    {
        Task<IEnumerable<UserModel>> UsersList();

        Task<UserModel> GetUser(int userId);
    }
}