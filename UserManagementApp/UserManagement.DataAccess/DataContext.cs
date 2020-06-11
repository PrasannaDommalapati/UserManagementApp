using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.DataAccess.Entity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserManagement.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        private string ConnectionString { get; }

        public DbSet<User> Users { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RoleTypes> RoleTypes { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DataContext(string connectionString) => ConnectionString = connectionString;

        public DataContext() : this("Data Source=PRASANNALAPTOP\\SQLEXPRESS;Initial Catalog=UserManagementApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ConnectionString != null)
            {
                optionsBuilder.UseSqlServer(ConnectionString, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public async Task UpdateAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }
    }
}