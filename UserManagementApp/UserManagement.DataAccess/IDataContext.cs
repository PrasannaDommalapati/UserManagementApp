using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UserManagement.DataAccess.Entity;

namespace UserManagement.DataAccess
{
    public interface IDataContext : IDisposable
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RoleTypes> RoleTypes { get; set; }

        public DbSet<Address> Addresses { get; set; }

        Task UpdateAsync();
    }
}
