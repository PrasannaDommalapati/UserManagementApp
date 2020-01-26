using Bogus;
using UserManagement.Business.Models;
using Xunit;

namespace UserManagement.Business.Tests.Models
{
    public class CredentialTests
    {
        [Fact]
        public void Ctor()
        {
            var faker = new Faker();

            var id = faker.Random.String();
            var key = faker.Random.String();

            var credential = new Credential
            {
                Id = id,
                Key = key
            };

            Assert.Equal(id, credential.Id);
            Assert.Equal(key, credential.Key);
        }
    }
}
