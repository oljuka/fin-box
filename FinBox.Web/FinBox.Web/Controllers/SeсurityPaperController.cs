using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinBox.Storage.Data;
using FinBox.Storage.Interfaces;
using FinBox.Storage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinBox.Web.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class SecurityPaperController : ControllerBase
	{
		private readonly ISecurityPaperDbService SecurityPaperDbService;

		private readonly ILogger<SecurityPaperController> _logger;

		public SecurityPaperController(ILogger<SecurityPaperController> logger)
		{
			_logger = logger;
			//TODO: Implement IoC
			SecurityPaperDbService = new SecurityPaperDbService();
		}

		[HttpGet]
		public IEnumerable<SecurityPaper> Get()
		{
			var securityPapers = SecurityPaperDbService.LoadAll()
				.ToArray();
			return securityPapers;
		}
	}
}
