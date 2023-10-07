using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
	public class RegisterGoogle
	{


		public string? Email { get; set; }

		public string? Username { get; set; }
		public string? Password { get; set; }

		public decimal? Roleid { get; set; }
	}
}
