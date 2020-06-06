using System;
using System.Collections.Generic;
using System.Text;
using notarius.DAL.Entities;
using notarius.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.EF
{
    public class EUnitOfWork
        : IUnitOfWork
    {
        private dealContext db;
        private ClientsRepository ClientsRepository;
        private DealRepository DealsRepository;
        private ServicesRepository ServiceRepository;
        private Services_providedRepository Service_providedRepository;

        public EUnitOfWork(dealContext context)
        {
            db = context;
        }
        public IclientRepository Clients
        {
            get
            {
                if (ClientsRepository == null)
                    ClientsRepository = new ClientsRepository(db);
                return ClientsRepository;
            }
        }
        public IdealRepository Deals
        {
            get
            {
                if (DealsRepository == null)
                    DealsRepository = new DealRepository(db);
                return DealsRepository;
            }
        }

        public IservicesRepository Services
        {
            get
            {
                if (ServiceRepository == null)
                    ServiceRepository = new ServicesRepository(db);
                return ServiceRepository;
            }
        }

        public Iservices_providedRepository ProvidedRepository
        {
            get
            {
                if (Service_providedRepository == null)
                    Service_providedRepository = new Services_providedRepository(db);
                return Service_providedRepository;
            }
        }

        public IclientRepository clients => throw new NotImplementedException();

        public IdealRepository deal => throw new NotImplementedException();

        public IservicesRepository services => throw new NotImplementedException();

        public Iservices_providedRepository services_provided => throw new NotImplementedException();

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}