using Bogus;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Business.Tests.Models
{
    public class OrganisationModelTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker();

            var organisationName = faker.Random.String();
            var addressModel = new AddressModel();
            var licence = faker.Random.String();
            var dateModified = faker.Date.Recent(1);

            var result = new OrganisationModel
            {
                OrganisationName = organisationName,
                AddressModel = addressModel,
                Licence = licence,
                DateModified = dateModified
            };

            Assert.Equal(organisationName, result.OrganisationName);
            Assert.Same(addressModel, result.AddressModel);
            Assert.Equal(licence, result.Licence);
            Assert.Equal(dateModified, result.DateModified);
        }
    }
}
