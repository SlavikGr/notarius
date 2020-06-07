using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using notarius.DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using notarius.Security;
using notarius.Security.Identity;

namespace notarius.BLL.Services.Impl
{
    public class DealService
        : IDealService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public DealService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<dealDTO> GetDeals(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            var osbbId = user.OSBBID;
            var dealsEntities =
                _database
                    .deal
                    .Find(z => z.DealID == osbbId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<deal, dealDTO>()
                    ).CreateMapper();
            var dealsDto =
                mapper
                    .Map<IEnumerable<deal>, List<dealDTO>>(
                        dealsEntities);
            return dealsDto;
        }

        public void AddDeal(dealDTO deal)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            if (deal == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }

            validate(deal);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<dealDTO, deal>()).CreateMapper();
            var dealEntity = mapper.Map<dealDTO, deal>(deal);
            _database.deal.Create(dealEntity);
        }

        private void validate(dealDTO deal)
        {
            if (string.IsNullOrEmpty(deal.DealDate))
            {
                throw new ArgumentException("DATE повинне містити значення!");
            }
        }

        public IEnumerable<dealDTO> GetDeal(int page)
        {
            throw new NotImplementedException();
        }
    }
}