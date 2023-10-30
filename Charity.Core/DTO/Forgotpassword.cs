using System.ComponentModel.DataAnnotations;

namespace Charity.Core.DTO
{
	public class Forgotpassword
	{

		public string? Email { get; set; }
		public string? verificationCode { get; set; }


	}
}
