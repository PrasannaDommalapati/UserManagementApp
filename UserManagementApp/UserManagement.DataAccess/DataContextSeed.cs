using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UserManagement.DataAccess.Entity;

namespace UserManagement.DataAccess
{
    public static class DataContextSeed
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            Roles(modelBuilder);

            return modelBuilder;
        }

        public static void Roles(ModelBuilder modelBuilder)
        {
            var roles = Enum.GetValues(typeof(UserRoleTypes))
                .Cast<UserRoleTypes>()
                .Select(r => new RoleTypes
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            modelBuilder.Entity<RoleTypes>()
                .HasData(roles);
        }
    }
}
