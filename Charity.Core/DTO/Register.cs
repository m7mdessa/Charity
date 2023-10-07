using System.ComponentModel.DataAnnotations;

namespace Charity.Core.DTO
{
	public class Register
	{
		public decimal Id { get; set; }

		public string? Email { get; set; }
		public string? Username { get; set; }

		public string? Password { get; set; }
        public string? Image { get; set; }

        public decimal? Roleid { get; set; }
	}
}
