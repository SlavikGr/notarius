using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using notarius.DAL.Entities;
using notarius.DAL.Repositories.Interfaces;
using DAL.EF;
using DAL.Repositories.Impl;

namespace DAL.tests
{
    class TestClientRepository
        : BaseRepository<clients>
    {
        public TestClientRepository(DbContext context)
        : base(context)
        {
        }
    }
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOfDBSetWithStreetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<dealContext>()
                .Options;
            var mockContext = new Mock<dealContext>(opt);
            var mockDbSet = new Mock<DbSet<clients>>();
            mockContext
                .Setup(context =>
                    context.Set<clients>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestClientRepository(mockContext.Object);

            clients expectedStreet = new Mock<clients>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<dealContext>()
                .Options;
            var mockContext = new Mock<dealContext>(opt);
            var mockDbSet = new Mock<DbSet<clients>>();
            mockContext
                .Setup(context =>
                    context.Set<clients>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestClientRepository(mockContext.Object);

            clients expectedStreet = new clients() { ClientID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.ClientID)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.ClientID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.ClientID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<dealContext>()
                .Options;
            var mockContext = new Mock<dealContext>(opt);
            var mockDbSet = new Mock<DbSet<clients>>();
            mockContext
                .Setup(context =>
                    context.Set<clients>(
                        ))
                .Returns(mockDbSet.Object);

            clients expectedStreet = new clients() { ClientID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.ClientID))
                    .Returns(expectedStreet);
            var repository = new TestClientRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.ClientID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.ClientID
                    ), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }
    }
}