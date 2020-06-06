using System;
using System.Collections.Generic;
using System.Text;
using notarius.DAL.Entities;
using notarius.DAL.Repositories.Interfaces;

namespace DAL.Repositories.Interfaces
{
    public interface IclientRepository
        : IRepository<clients>
    {
    }
}