namespace Charity.Infra.Service
{
	internal class PasswordResetInfo
	{
		public string Email { get; set; }
		public string VerificationCode { get; set; }
		public DateTime ExpirationTime { get; set; }
	}
}