using DockService.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockService.Infrastructure.Database
{
    public class DockDbContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }

        public DockDbContext(DbContextOptions<DockDbContext> options) : base(options)
        {
        }
    }
}
