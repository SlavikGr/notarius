using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using notarius.DAL.Entities;
using notarius.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using BLL.DTO;
using CCL.Security;
using System.Security.Permissions;
using CCL.Security.Identity;
using AutoMapper;


namespace BLL.Services.Impl
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
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<dealDTO> GetSellers(int pageNumber)
        {
            var deal = SecurityContext.GetDeal();
            var login = deal.GetType();
            if (login != typeof(Owner))
            {
                throw new MethodAccessException();
            }
            var ServiceId = deal.ServiceID;
            var ServiceEntities =
                _database
                    .services
                    .Find(z => z.ServiceID == ServiceId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<services, servicesDTO>()
                    ).CreateMapper();
            var servicesDTO =
                mapper
                    .Map<IEnumerable<services>, List<servicesDTO>>(
                        ServiceEntities);
            return (IEnumerable<servicesDTO>)servicesDTO;



        }
    }
}