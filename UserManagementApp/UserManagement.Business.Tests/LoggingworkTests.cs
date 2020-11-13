using System;
using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess;
using Xunit;

namespace UserManagement.Business.Tests
{
    public class LoggingWorkTests: IDisposable
    {
        private ILoggingWork _loggingWork;
        private UserDataContext _userDataContext;
        
        public LoggingWorkTests()
        {
            var options = new DbContextOptionsBuilder<UserDataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _userDataContext = new UserDataContext(options);

            _userDataContext.Database.EnsureCreated();
            _userDataContext.SeedData();
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _loggingWork.CreateUserAsync(null));
        }

        public void Dispose()
        {
            _userDataContext.Database.EnsureDeleted();
            _userDataContext.Dispose();
        }
    }
}
