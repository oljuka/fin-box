using System;
using System.Collections.Generic;
using System.Text;
using FinBox.Storage.Data;

namespace FinBox.Storage.Interfaces
{
	public interface ISecurityPaperDbService
	{
		IEnumerable<SecurityPaper> LoadAll();

		SecurityPaper GetById(int id);
	}
}
