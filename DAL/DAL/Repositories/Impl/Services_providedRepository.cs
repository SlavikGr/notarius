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
    public class Services_providedRepository
    : BaseRepository<services_provided>, Iservices_providedRepository
    {
        internal Services_providedRepository(dealContext context)
            : base(context)
        {

        }
    }
}