using System.ComponentModel.DataAnnotations;

namespace Charity.Core.DTO
{
	public class Login
	{
		public string? id { get; set; }
		public string? Username { get; set; }
		public string? token { get; set; }
		public string? Password { get; set; }
		public string? Roleid { get; set; }
	}
}
