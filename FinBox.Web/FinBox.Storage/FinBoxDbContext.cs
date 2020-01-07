using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FinBox.Storage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinBox.Storage
{
	public class FinBoxDbContext : DbContext
	{
		public DbSet<SecurityPaper> SecurityPapers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();
				var connectionString = configuration.GetConnectionString("DefaultConnection");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}
	}
	
}
