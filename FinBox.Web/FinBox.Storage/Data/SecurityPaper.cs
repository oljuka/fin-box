using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinBox.Storage.Data
{
	public class SecurityPaper
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Column(TypeName ="nvarchar(50)")]
		public string Code { get; set; }

		[Required]
		public Currency Currency { get; set; }
	}
}
