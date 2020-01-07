using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinBox.Storage.Data;
using FinBox.Storage.Interfaces;

namespace FinBox.Storage.Services
{
	public class SecurityPaperDbService : ISecurityPaperDbService
	{
		public IEnumerable<SecurityPaper> LoadAll()
		{
			using (var db = new FinBoxDbContext())
			{
				var securityPapers = db.SecurityPapers
					.OrderBy(b => b.Name)
					.ToList();
				return securityPapers;
			}
		}

		public SecurityPaper GetById(int id)
		{
			using (var db = new FinBoxDbContext())
			{
				var securityPaper = db.SecurityPapers
					.FirstOrDefault(b => b.Id == id);
				return securityPaper;
			}
		}
	}
}
