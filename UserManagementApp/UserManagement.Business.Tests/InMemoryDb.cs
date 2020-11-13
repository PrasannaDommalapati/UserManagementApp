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
                    Id = faker.Random.Number(),
                    Address = new Address(),
                    Licence = faker.Random.String(),
                    OrganisationName = faker.Company.CompanyName(),
                    DateCreated = faker.Date.Past(),
                    DateModified = faker.Date.Soon(1)
                },
                new Organisation
                {
                    Id = faker.Random.Number(),
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

            return context;
        }
    }
}