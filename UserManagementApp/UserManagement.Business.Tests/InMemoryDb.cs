using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business.Tests
{
    public static class InMemoryDb
    {

        public static UserDataContext SetUp()
        {
            var options = new DbContextOptionsBuilder<UserDataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var userDataContext = new UserDataContext(options);

            userDataContext.Database.EnsureCreated();

            return SeedData(userDataContext);
        }

        public static UserDataContext SeedData(this UserDataContext context)
        {
            var faker = new Faker("en");
            
            //add organisations to data context
            var orgList = new List<Organisation>
            {
                new Organisation
                {
                    Address = new Address(),
                    Licence = faker.Random.String(),
                    OrganisationName = faker.Company.CompanyName(),
                    DateCreated = faker.Date.Past(),
                    DateModified = faker.Date.Soon(1)
                },
                new Organisation
                {
                    Address = new Address(),
                    Licence = faker.Random.String(),
                    OrganisationName = faker.Company.CompanyName(),
                    DateCreated = faker.Date.Past(),
                    DateModified = faker.Date.Soon(1)
                }
            };
            context.Organisations.AddRange(orgList);
            
            //add role types to data context
            var roles = Enum.GetValues(typeof(UserRoleTypes))
                .Cast<UserRoleTypes>()
                .Select(r => new RoleTypes
                {
                    Id = (int)r,
                    Name = r.ToString()
                });
            
            context.RoleTypes.AddRange(roles);
            
            //add address to data context
            var addressList = new List<Address>
            {
                new Address
                {
                    Postcode = faker.Address.ZipCode(),
                    AddressLine = faker.Address.StreetAddress(),
                    County = faker.Address.County(),
                    OrganisationId = orgList.First().Id,
                    DateCreated = faker.Date.Past(),
                    DateModified = faker.Date.Soon(1),
                    TownOrCity = faker.Address.City()
                },                
                new Address
                {
                    Postcode = faker.Address.ZipCode(),
                    AddressLine = faker.Address.StreetAddress(),
                    County = faker.Address.County(),
                    OrganisationId = orgList.First().Id,
                    DateCreated = faker.Date.Past(),
                    DateModified = faker.Date.Soon(1),
                    TownOrCity = faker.Address.City()
                }
            };

            context.Addresses.AddRange(addressList);

            var users = new List<User>
            {
                new User
                {
                    IsActive = false,
                    FirstName = "Tests",
                    Email = "test@test.com",
                    LastName = "Tests"
                },
                new User
                {
                    IsActive = true,
                    FirstName = "Tests1",
                    Email = "test@tester.com",
                    LastName = "Tests1"
                }
            };

            context.Users.AddRange(users);

            return context;
        }
    }
}