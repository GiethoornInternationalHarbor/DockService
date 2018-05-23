using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockService.Infrastructure.Database
{
#if DEBUG
	public class DockDbContextFactory : IDesignTimeDbContextFactory<DockDbContext>
	{
		public DockDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<DockDbContext>();
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DockService;Trusted_Connection=True;MultipleActiveResultSets=true");

			return new DockDbContext(optionsBuilder.Options);
		}
	}
#endif
}
