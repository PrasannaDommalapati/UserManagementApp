using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserManagement.DataAccess.Entity;

namespace UserManagement.DataAccess
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options):base(options) { }

        public UserDataContext(string connectionString) => ConnectionString = connectionString;

        private string ConnectionString { get; }

        public DbSet<User> Users { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RoleTypes> RoleTypes { get; set; }

        public DbSet<Address> Addresses { get; set; }

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