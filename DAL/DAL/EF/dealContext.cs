using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using notarius.DAL.Entities;

namespace DAL.EF
{
    public class dealContext
        : DbContext
    {
        public DbSet<deal> Deals { get; set; }
        public DbSet<clients> Clients { get; set; }
        public DbSet<services> Services { get; set; }
        public DbSet<services_provided> Services_provided { get; set; }
        public dealContext(DbContextOptions options)
            : base(options) { }
    }
}