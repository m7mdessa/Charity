using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
	public class Issues
	{
		public decimal Id { get; set; }

		public string? Issuedescription { get; set; }

		public DateTime? Datereported { get; set; }

		public string? Username { get; set; }

		public string? Status { get; set; }
		public string? response { get; set; }
	}
}
