using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DataAccess;
using UserManagement.Business;
using Xunit;

namespace UserManagement.Business.Tests
{
    public class UnitOfWorkTests
    {
        private IDataContext DataContext;

        public UnitOfWorkTests()
        {
            DataContext = new Mock<IDataContext>().Object;
        }

        [Fact]
        public void Ctor_Null_DataContext()
        {
            //Assert.ThrowsAny<ArgumentNullException>(d =>  UnitOfWork(null));
        }
    }
}
