using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using BLL.DTO;
using notarius.Security;
using System.Security.Permissions;
using notarius.Security.Identity;
using AutoMapper;
using Xunit;
using BLL.Services.Impl;
using Moq;
using DAL.Repositories.Interfaces;
using notarius.DAL.Entities;
using deal = notarius.DAL.Entities.deal;

namespace BLL.Tests
{
    public class DealServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
​
    // Act
    // Assert
    Assert.Throws<ArgumentNullException>(
        () => new DealService(nullUnitOfWork)
    );
        }
    }
}
