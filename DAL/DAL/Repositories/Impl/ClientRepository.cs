using System;
using System.Collections.Generic;
using System.Text;
using notarius.DAL.Entities;
using notarius.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class ClientsRepository
        : BaseRepository<clients>, IclientRepository
    {
        internal ClientsRepository(dealContext context)
            : base(context)
        {

        }
    }
}