using AutoMapper;
using Bogus;
using System.Collections.Generic;
using UserManagement.Business.Mappings;
using UserManagement.Business.Models;
using UserManagement.DataAccess.Entity;
using Xunit;

namespace UserManagement.Business.Tests.Mappings
{
    public class ToUserTests
    {
        private readonly IMapper Mapper;
        private readonly Faker Faker;

        public ToUserTests()
        {
            Mapper = AutoMapperConfiguration.Create();
            Faker = new Faker();
        }

        [Fact]
        public void Ctor_Success()
        {
            //arrange
            var user = new User
            {
                Id = Faker.Random.Number(),
                Email = Faker.Random.String(),
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                Birthday = Faker.Date.Recent(500),
                DateModified = Faker.Date.Recent(5),
                Organisations = new List<Organisation> {
                    new Organisation
                    {
                        Id = 10
                    } 
                },
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Role = nameof(UserRoleTypes.Admin)
                    }
                }
            };
            //act
            var userModel = Mapper.Map<UserModel>(user);

            //assert
            Assert.Equal(user.Id, userModel.Id);
            Assert.Equal(user.Email, userModel.Email);
            Assert.Equal(user.FirstName, userModel.FirstName);
            Assert.Equal(user.LastName, userModel.LastName);
            Assert.Equal(user.Birthday, userModel.Birthday);
            Assert.Equal(user.DateModified, userModel.DateModified);

            Assert.True(userModel.Roles.Count == 1);
            Assert.Equal(user.Roles[0].Role, userModel.Roles[0].Role);

            Assert.True(userModel.Organisations.Count == 1);
            Assert.Equal(user.Organisations[0].Id, userModel.Organisations[0].Id);
        }
    }
}