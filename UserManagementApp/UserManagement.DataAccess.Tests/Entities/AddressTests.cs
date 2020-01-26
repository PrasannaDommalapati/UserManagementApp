using Bogus;
using UserManagement.DataAccess.Entity;
using Xunit;

namespace UserManagement.DataAccess.Tests.Entities
{
    public class AddressTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker("en");

            var organisationId = faker.Random.Number();
            var addressLine = faker.Random.String();
            var county = faker.Random.String();
            var townOrCity = faker.Random.String();
            var postcode = faker.Random.String();
            var dateModified = faker.Date.Recent(1);

            var address = new Address
            {
                County = county,
                OrganisationId = organisationId,
                AddressLine = addressLine,
                TownOrCity = townOrCity,
                Postcode = postcode,
                DateModified = dateModified
            };

            Assert.Equal(organisationId, address.OrganisationId);
            Assert.Equal(county, address.County);
            Assert.Equal(townOrCity, address.TownOrCity);
            Assert.Equal(addressLine, address.AddressLine);
            Assert.Equal(postcode, address.Postcode);
            Assert.Equal(dateModified, address.DateModified);
        }
    }
}
