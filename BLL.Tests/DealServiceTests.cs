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
    Assert.Throws<ArgumentNullException>(
        () => new DealService(nullUnitOfWork)
    );
        }
    }
}