using Bogus;
using UserManagement.DataAccess.Entity;
using Xunit;

namespace UserManagement.DataAccess.Tests.Entities
{
    public class OrganisationTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker();

            var organisationName = faker.Random.String();
            var address = new Address();
            var licence = faker.Random.String();
            var dateModified = faker.Date.Recent(1);

            var result = new Organisation
            {
                OrganisationName = organisationName,
                Address = address,
                Licence = licence,
                DateModified = dateModified
            };

            Assert.Equal(organisationName, result.OrganisationName);
            Assert.Same(address, result.Address);
            Assert.Equal(licence, result.Licence);
            Assert.Equal(dateModified, result.DateModified);
        }
    }
}
