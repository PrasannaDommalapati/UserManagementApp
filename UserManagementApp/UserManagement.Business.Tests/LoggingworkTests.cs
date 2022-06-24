using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess;
using UserManagement.DataAccess.Entity;
using Xunit;

namespace UserManagement.Business.Tests
{
    public class LoggingWorkTests : IDisposable
    {
        private ILoggingWork _loggingWork;
        private UserDataContext _userDataContext;

        public LoggingWorkTests()
        {
            //SetupInMemoryDb();
            _loggingWork = new LoggingWork(_userDataContext);
        }

        [Fact]
        public void Ctor_Null_DataContext()
        {
            Assert.Throws<ArgumentNullException>(() => new LoggingWork(null));
        }

        [Fact]
        public void CreateUserAsync_Null_UserModel()
        {
            // Assert.ThrowsAsync<ArgumentNullException>(async () => await _loggingWork.CreateUserAsync(null));
        }

        public void Dispose()
        {
            _userDataContext.Database.EnsureDeleted();
            _userDataContext.Dispose();
        }

        private void SetupInMemoryDb()
        {
            var dbContextOptions = new DbContextOptionsBuilder<UserDataContext>()
                .UseInMemoryDatabase(databaseName: "Test_UserData")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            _userDataContext = new UserDataContext(dbContextOptions);
            _userDataContext.Database.EnsureCreated();

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
                    DateModified = faker.Date.Soon(2),
                    Id = faker.Random.Number()

                }
            };
            _userDataContext.Organisations.AddRange(orgList);

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
                    TownOrCity = faker.Address.City(),
                    Id = faker.Random.Number()
                }
            };

            _userDataContext.Addresses.AddRange(addressList);

            var users = new List<User>
            {
                new User
                {
                    IsActive = false,
                    FirstName = "Tests",
                    Email = "test@test.com",
                    LastName = "Tests",
                    Id = faker.Random.Number()
                }
            };

            _userDataContext.Users.AddRange(users);

            _userDataContext.SaveChanges();
        }
    }
}
