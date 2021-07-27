using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.DatabaseContext.DataContextModel
{
    public class DotNetCoreDBContext : IdentityDbContext
    {
        public DotNetCoreDBContext(DbContextOptions<DotNetCoreDBContext> options) : base( options)
        {
        }

        public DbSet<Item> Items { get; set; }
       
    }
}
