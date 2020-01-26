using Bogus;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Business.Tests.Models
{
    public class AddressModelTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker();

            var organisationId = faker.Random.Number();
            var addressLine = faker.Random.String();
            var county = faker.Random.String();
            var townOrCity = faker.Random.String();
            var postcode = faker.Random.String();
            var dateModified = faker.Date.Recent(1);

            var addressModel = new AddressModel
            {
                County = county,
                OrganisationId = organisationId,
                AddressLine = addressLine,
                TownOrCity = townOrCity,
                Postcode = postcode,
                DateModified = dateModified
            };

            Assert.Equal(organisationId, addressModel.OrganisationId);
            Assert.Equal(county, addressModel.County);
            Assert.Equal(townOrCity, addressModel.TownOrCity);
            Assert.Equal(addressLine, addressModel.AddressLine);
            Assert.Equal(postcode, addressModel.Postcode);
            Assert.Equal(dateModified, addressModel.DateModified);
        }
    }
}
