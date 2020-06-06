using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IclientRepository clients { get; }
        IdealRepository deal { get; }
        IservicesRepository services { get; }
        Iservices_providedRepository services_provided { get; }
        void Save();

    }
}
