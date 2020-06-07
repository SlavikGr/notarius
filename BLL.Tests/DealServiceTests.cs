using notarius.BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using notarius.DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using notarius.Security;
using notarius.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class DealServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new DealService(nullUnitOfWork));
        }

        [Fact]
        public void GetDeals_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IDealService dealService = new DealService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => dealService.GetDeal(0));
        }

        [Fact]
        public void GetDeals_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var dealService = GetDealService();

            // Act
            var actualDealDto = dealService.GetDeal(0).First();

            // Assert
            Assert.True(
                actualDealDto.DealID == 1
                && actualDealDto.Summa == 123
                && actualDealDto.DealDate == "24.05.2020"
                && actualDealDto.ClientID == 2
                );
        }

        IDealService GetDealService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedDeal = new deal() { DealID = 1, Summa = 123, DealDate = "24.05.2020", ClientID = 2 };
            var mockDbSet = new Mock<IdealRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<deal, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<deal>() { expectedDeal }
                    );
            mockContext
                .Setup(context =>
                    context.deal)
                .Returns(mockDbSet.Object);

            IDealService streetService = new DealService(mockContext.Object);

            return streetService;
        }
    }
}