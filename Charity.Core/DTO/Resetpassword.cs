using System.ComponentModel.DataAnnotations;

namespace Charity.Core.DTO
{
	public class Resetpassword
	{
		public string? VerificationCode { get; set; }
		public string? NewPassword { get; set; }
	}
}
