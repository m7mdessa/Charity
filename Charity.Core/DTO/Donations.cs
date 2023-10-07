using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
	public class Donations
	{
		public decimal? Amount { get; set; }

		public DateTime? Donationdate { get; set; }

		public string? Status { get; set; }

		public string? Charityname { get; set; }

		public string? Username { get; set; }
	}
}
